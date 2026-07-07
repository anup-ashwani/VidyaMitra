
using Microsoft.Extensions.DependencyInjection;
using VidyaMitra.Application;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Application.Services;
using VidyaMitra.Repository.Repositories;

namespace VidyaMitra.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            // Register application services
            services.AddScoped<IStudentRepository, StudentRepository>();

            //services.AddApplicationDI();

            return services;
        }
    }
}
