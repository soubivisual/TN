using Microsoft.EntityFrameworkCore;
using TN.Modules.Logger.Domain.ApplicationLogs.Entities;

namespace TN.Modules.Logger.Infrastructure.DataAccess
{
    internal class LoggerDbContext : DbContext
    {
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

        public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options) { }

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

            modelBuilder.HasDefaultSchema("logger");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
