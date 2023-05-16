using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Persistance.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration[$"{nameof(ConnectionStrings)}:{ConnectionStrings.Database}"];
            services.AddDbContext<T>(x => x.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection DatabaseMigration(this IServiceCollection services)
        {
            services.AddHostedService<DbContextMigration>();

            return services;
        }
    }
}
