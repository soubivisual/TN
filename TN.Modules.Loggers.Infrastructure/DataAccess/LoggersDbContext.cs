using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.ApplicationLogs.Entities;

namespace TN.Modules.Loggers.Infrastructure.DataAccess
{
    internal class LoggersDbContext : DbContext
    {
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

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
