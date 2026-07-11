using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VidyaMitra.Api;
using VidyaMitra.API.Dto;
using VidyaMitra.API.Extensions;
using VidyaMitra.API.ApiUtility;
using VidyaMitra.Application;
using VidyaMitra.Domain;
using VidyaMitra.Repository;
using VidyaMitra.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

//Configure EntityFramework 
builder.Services.AddDbContext<VidyaMitraDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VidyaMitraConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

////Jwt Configuration
//builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

// Configure static data
SD.AuthApiBase = builder.Configuration["ServiceUrls:AuthApiBase"];

//---Register Dependencies------------
builder.Services.AddDomainDI();
builder.Services.AddApplicationDI();
builder.Services.AddRepositoryDI();
builder.Services.AddApiDI();

//------------------------------------
builder.AddAppAuthentication();
//------------------------------------
var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/openapi/v1.json", "Open Api V1");
    //});
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

//Position Middleware correctly in the request lifecycle
app.UseAuthentication(); // Always goes before Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
