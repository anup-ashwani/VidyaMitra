
using VidyaMitra.API.Auth.Services;
using VidyaMitra.API.Auth.Services.Interface;

namespace VidyaMitra.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            // Configure the HTTP Client used exclusively to fetch tokens
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddHttpClient<IAuthService, AuthService>();

            // Register application services
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
