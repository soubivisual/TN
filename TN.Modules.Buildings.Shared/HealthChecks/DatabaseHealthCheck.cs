using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using TN.Modules.Buildings.Shared.Persistance.Database;

namespace TN.Modules.Buildings.Shared.HealthChecks
{
    internal class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMultiTenantStore<TenantInfo> _multiTenantStore;

        public DatabaseHealthCheck(IServiceProvider serviceProvider, IMultiTenantStore<TenantInfo> multiTenantStore)
        {
            _serviceProvider = serviceProvider;
            _multiTenantStore = multiTenantStore;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var dbContextTypes = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

                using var scope = _serviceProvider.CreateScope();
                foreach (var dbContextType in dbContextTypes)
                {
                    var tenants = await _multiTenantStore.GetAllAsync();

                    foreach(var tenant in tenants)
                    {
                        var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContextBase;
                        if (dbContext is null)
                        {
                            continue;
                        }

                        dbContext.SetCurrentTenant(tenant);

                        await dbContext.Database.OpenConnectionAsync();
                        await dbContext.Database.CloseConnectionAsync();
                    }
                }

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
