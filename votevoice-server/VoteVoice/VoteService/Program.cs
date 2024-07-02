using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using VoteService.Business.Services;
using VoteService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration["GatewayService:Host"] = builder.Configuration["GatewayService:Host"];
builder.Configuration["GatewayService:Port"] = builder.Configuration["GatewayService:Port"];

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


string logPath = builder.Configuration.GetSection("Logging:LogPath").Value;
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(logPath)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IVoteService, VoteService.Business.Services.Services.VoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//TO run migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<DataContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        throw;
    }
}

app.Run();
