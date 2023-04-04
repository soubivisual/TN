using Microsoft.EntityFrameworkCore;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Menus.Aggregates;
using TN.Modules.Configurations.Domain.Services.Aggregates;
using TN.Modules.Configurations.Domain.Services.Entities;
using TN.Modules.Configurations.Domain.Tenants.Aggregates;
using TN.Modules.Configurations.Domain.Tenants.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess
{
    internal class ConfigurationsDbContext : DbContext
    {
        internal DbSet<Catalog> Catalogs { get; set; }

        internal DbSet<CatalogDescription> CatalogDescriptions { get; set; }

        internal DbSet<Menu> Menus { get; set; }

        internal DbSet<Service> Services { get; set; }

        internal DbSet<Provider> Providers { get; set; }

        internal DbSet<Tenant> Tenants { get; set; }

        internal DbSet<Company> Companies { get; set; }

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

            modelBuilder.HasDefaultSchema("Configurations");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // Solución del Error: Introducing FOREIGN KEY constraint 'FK_XXXXX' on table 'XXX' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
