using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Configurations.Application.Contracts;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Menus.Repositories;
using TN.Modules.Configurations.Domain.Providers.Repositories;
using TN.Modules.Configurations.Domain.Services.Repositories;
using TN.Modules.Configurations.Domain.Tenants.Repositories;
using TN.Modules.Configurations.Infrastructure.Caching;
using TN.Modules.Configurations.Infrastructure.DataAccess;
using TN.Modules.Configurations.Infrastructure.DataAccess.Catalogs;
using TN.Modules.Configurations.Infrastructure.DataAccess.Companys;
using TN.Modules.Configurations.Infrastructure.DataAccess.Menus;
using TN.Modules.Configurations.Infrastructure.DataAccess.Providers;
using TN.Modules.Configurations.Infrastructure.DataAccess.Services;
using TN.Modules.Configurations.Infrastructure.DataAccess.Tenants;

namespace TN.Modules.Configurations.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<ConfigurationsDbContext>();

            services.AddTransient<IConfigurationsAccessModule, ConfigurationsAccessModule>();

            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICatalogDescriptionRepository, CatalogDescriptionRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<ICacheDataSource, CacheDataSource>();

            return services;
        }
    }
}
