using System.Text;
using VidyaMitra.Application.DTOs;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Repository.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using VidyaMitra.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Bind JwtSettings Options Pattern
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// 2. Register application services
// Add scoped services here, e.g. builder.Services.AddScoped<IYourService, YourService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 3. Configure JWT Authentication Pipeline
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        ClockSkew = TimeSpan.Zero // Immediate expiration validation
    };
});

builder.Services.AddControllers();
var app = builder.Build();

// 4. Position Middleware correctly in the request lifecycle
app.UseAuthentication(); // Always goes before Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
