using UserService.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UserService.Business.Services.Services;
using UserService.Business.Services;
using UserService.XObjects.SeedScripts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMemoryCache();
builder.Services.AddLazyCache();

string logPath = builder.Configuration.GetSection("Logging:LogPath").Value;
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(logPath)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var jwtSetting = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSetting);

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService.Business.Services.Services.UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
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
        SeedDataExtension.Seed(app.Services);
    }
    catch (Exception ex)
    {
        throw;
    }
}

app.Run();
