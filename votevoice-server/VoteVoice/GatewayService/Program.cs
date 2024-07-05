using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Set environment variables for shared configurations
Environment.SetEnvironmentVariable("USER_SERVICE_HOST", builder.Configuration["UserService:Host"]);
Environment.SetEnvironmentVariable("USER_SERVICE_PORT", builder.Configuration["UserService:Port"]);
Environment.SetEnvironmentVariable("POLL_SERVICE_HOST", builder.Configuration["PollService:Host"]);
Environment.SetEnvironmentVariable("POLL_SERVICE_PORT", builder.Configuration["PollService:Port"]);
Environment.SetEnvironmentVariable("VOTE_SERVICE_HOST", builder.Configuration["VoteService:Host"]);
Environment.SetEnvironmentVariable("VOTE_SERVICE_PORT", builder.Configuration["VoteService:Port"]);

builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("http://localhost:4200", "https://votevoice.vercel.app")
    .AllowAnyHeader().
    AllowAnyMethod()
    .AllowCredentials();
}));

// Configure JWT Authentication
var securityKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero, // To consider custom time
    };
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read the ocelot-template.json file
var ocelotTemplate = File.ReadAllText("Ocelot.json");

// Replace the placeholders with actual values
var ocelotConfig = ocelotTemplate
    .Replace("{UserServiceHost}", Environment.GetEnvironmentVariable("USER_SERVICE_HOST"))
    .Replace("{UserServicePort}", Environment.GetEnvironmentVariable("USER_SERVICE_PORT"))
    .Replace("{PollServiceHost}", Environment.GetEnvironmentVariable("POLL_SERVICE_HOST"))
    .Replace("{PollServicePort}", Environment.GetEnvironmentVariable("POLL_SERVICE_PORT"))
    .Replace("{VoteServiceHost}", Environment.GetEnvironmentVariable("VOTE_SERVICE_HOST"))
    .Replace("{VoteServicePort}", Environment.GetEnvironmentVariable("VOTE_SERVICE_PORT"));

// Write the modified content to ocelot.json
File.WriteAllText("Ocelot.json", ocelotConfig);

// Load Ocelot configuration
builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Configure Ocelot to handle the requests
app.UseOcelot().Wait();

app.MapControllers();

app.Run();
