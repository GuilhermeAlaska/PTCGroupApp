using Application.Common.Configs;
using System.Reflection;
namespace API.Configs
{
    public static class LoadConfigs
    {
        public static IServiceCollection AddConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.Configure<JwtPasswordConfig>(configuration.GetSection("JwtPasswordConfig"));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}