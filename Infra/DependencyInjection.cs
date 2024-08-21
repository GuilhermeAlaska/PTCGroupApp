using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Services;
using Infra.Persistence;
using Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("AppConnection"),
                    p =>
                    {
                        p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        p.EnableRetryOnFailure(maxRetryCount: 4);
                    });
            });

            return services;
        }
    }
}