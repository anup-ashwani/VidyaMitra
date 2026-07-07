
using VidyaMitra.Application;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Repository;
using VidyaMitra.Repository.Data;
using VidyaMitra.Repository.Repositories;

namespace VidyaMitra.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            // Register application services
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddApplicationDI();
            //services.AddRepositoryDI();

            return services;
        }
    }
}
