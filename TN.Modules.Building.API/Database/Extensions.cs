using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Building.API.Database
{
    public static class Extensions
    {
        public static IServiceCollection DatabaseMigration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<DbContextMigration>();

            // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
            // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
