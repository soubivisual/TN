using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Persistance.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddDbContext<T>();

            return services;
        }

        public static IServiceCollection DatabaseMigration(this IServiceCollection services)
        {
            services.AddHostedService<DbContextMigration>();

            return services;
        }
    }
}
