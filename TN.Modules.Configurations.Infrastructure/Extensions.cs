using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Configurations.Application.Contracts;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Infrastructure.DataAccess;
using TN.Modules.Configurations.Infrastructure.Repositories;

namespace TN.Modules.Configurations.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<ConfigurationsDbContext>();

            services.AddTransient<IConfigurationsAccessModule, ConfigurationsAccessModule>();

            services.AddScoped<ICatalogRepository, CatalogRepository>();

            return services;
        }
    }
}
