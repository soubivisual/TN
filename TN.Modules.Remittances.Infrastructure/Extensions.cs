using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Infrastructure.Persistance.Database;
using TN.Modules.Remittances.Application.Contracts;
using TN.Modules.Remittances.Domain.Remittances.Repositories;
using TN.Modules.Remittances.Infrastructure.DataAccess;
using TN.Modules.Remittances.Infrastructure.Repositories;

namespace TN.Modules.Remittances.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDatabase<RemittancesDbContext>();

            services.AddTransient<IRemittancesAccessModule, RemittancesAccessModule>();

            services.AddScoped<IRemittanceRepository, RemittanceRepository>();

            return services;
        }
    }
}
