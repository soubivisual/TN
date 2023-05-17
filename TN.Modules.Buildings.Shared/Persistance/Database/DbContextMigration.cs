using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TN.Modules.Buildings.Shared.Persistance.Database
{
    internal sealed class DbContextMigration : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DbContextMigration> _logger;
        private readonly IMultiTenantStore<TenantInfo> _multiTenantStore;

        public DbContextMigration(IServiceProvider serviceProvider, ILogger<DbContextMigration> logger, IMultiTenantStore<TenantInfo> multiTenantStore)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _multiTenantStore = multiTenantStore;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();
            foreach (var dbContextType in dbContextTypes)
            {
                var tenants = await _multiTenantStore.GetAllAsync();

                foreach (var tenant in tenants)
                {
                    var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContextBase;
                    if (dbContext is null)
                    {
                        continue;
                    }

                    dbContext.SetCurrentTenant(tenant);

                    _logger.LogInformation("Running DB context: {dbContextTypeName}...", dbContext.GetType().Name);
                    await dbContext.Database.MigrateAsync(cancellationToken);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
