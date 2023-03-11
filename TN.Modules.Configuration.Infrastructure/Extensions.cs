using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Building.Infrastructure.Persistance.Database;
using TN.Modules.Configuration.Application.Contracts;
using TN.Modules.Configuration.Domain.Catalogs.Repositories;
using TN.Modules.Configuration.Infrastructure.DataAccess;
using TN.Modules.Configuration.Infrastructure.Repositories;

namespace TN.Modules.Configuration.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<ConfigurationDbContext>();

            services.AddTransient<IConfigurationAccessModule, ConfigurationAccessModule>();

            services.AddScoped<ICatalogRepository, CatalogRepository>();

            return services;
        }
    }
}
