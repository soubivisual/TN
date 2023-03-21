using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.API.Database
{
    public static class Extensions
    {
        public static IServiceCollection DatabaseMigration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<DbContextMigration>();

            return services;
        }
    }
}
