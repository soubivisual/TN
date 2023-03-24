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

        public DbContextMigration(IServiceProvider serviceProvider, ILogger<DbContextMigration> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(q => q.GetTypes())
                .Where(q => typeof(DbContext).IsAssignableFrom(q) && !q.IsInterface && q != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();
            foreach (var dbContextType in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContext;
                if (dbContext is null)
                {
                    continue;
                }

                _logger.LogInformation("Running DB context: {dbContextTypeName}...", dbContext.GetType().Name);
                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
