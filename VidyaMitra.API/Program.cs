using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VidyaMitra.Api;
using VidyaMitra.API.Extensions;
using VidyaMitra.Application;
using VidyaMitra.Domain;
using VidyaMitra.Repository;
using VidyaMitra.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

//Configure EntityFramework 
//builder.Services.AddDbContext<VidyaMitraDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VidyaMitraConnection")));

// Fetch connection string and inject PostgreSQL provider setup
builder.Services.AddDbContext<VidyaMitraDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VidyaMitraConnection")));

////Configure AutoMapper
//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

//---Register Dependencies------------
builder.Services.AddApiDI();
builder.Services.AddApplicationDI();
builder.Services.AddRepositoryDI();
builder.Services.AddDomainDI();

builder.Services.AddOpenApi();
//---------------

builder.AddAppAuthentication();
//builder.Services.AddAuthorization(); //Require when start Authorization process

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Open Api V1");
    });

    app.MapScalarApiReference();
}

//Position Middleware correctly in the request lifecycle
app.UseAuthentication(); // Always goes before Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
