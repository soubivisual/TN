using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates;
using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;
using TN.Modules.Loggers.Domain.UserActivities.Aggregates;

namespace TN.Modules.Loggers.Infrastructure.DataAccess
{
    internal class LoggersDbContext : DbContext
    {
        internal DbSet<ApplicationLog> ApplicationLogs { get; set; }

        internal DbSet<TraceLog> TraceLogs { get; set; }

        internal DbSet<UserActivity> UserActivities { get; set; }

        public LoggersDbContext(DbContextOptions<LoggersDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Loggers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
