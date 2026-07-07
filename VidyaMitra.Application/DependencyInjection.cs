
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Application.Services;
using VidyaMitra.Domain;

namespace VidyaMitra.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            //Configure AutoMapper
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register application services
            services.AddScoped<IStudentService, StudentService>();

            //services.AddDomainDI();

            return services;
        }
    }
}
