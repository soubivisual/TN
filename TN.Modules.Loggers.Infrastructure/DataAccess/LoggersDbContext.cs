using Microsoft.EntityFrameworkCore;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Buildings.Shared.Tenants;
using TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates;
using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;
using TN.Modules.Loggers.Domain.UserActivities.Aggregates;

namespace TN.Modules.Loggers.Infrastructure.DataAccess
{
    internal class LoggersDbContext : DbContextBase
    {
        internal DbSet<ApplicationLog> ApplicationLogs { get; set; }

        internal DbSet<TraceLog> TraceLogs { get; set; }

        internal DbSet<UserActivity> UserActivities { get; set; }

        private readonly string _schemaName;

        public LoggersDbContext(DbContextOptions<LoggersDbContext> options, ITenantService tenantService) : base(options, tenantService)
        {
            _schemaName = this.GetType().Name.Replace(nameof(DbContext), string.Empty);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(x => x.MigrationsHistoryTable("__MigrationsHistory", _schemaName));
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(_schemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
