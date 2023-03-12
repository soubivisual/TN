using Microsoft.EntityFrameworkCore;
using TN.Modules.Configurations.Domain.Catalogs.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess
{
    internal class ConfigurationsDbContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }

        public ConfigurationsDbContext(DbContextOptions<ConfigurationsDbContext> options) : base(options) { }

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

            modelBuilder.HasDefaultSchema("configurations");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
