using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Menus.Aggregates;
using TN.Modules.Configurations.Domain.Services.Aggregates;
using TN.Modules.Configurations.Domain.Services.Entities;
using TN.Modules.Configurations.Domain.Tenants.Aggregates;
using TN.Modules.Configurations.Domain.Tenants.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess
{
    internal class ConfigurationsDbContext : DbContextBase
    {
        internal DbSet<Catalog> Catalogs { get; set; }

        internal DbSet<CatalogDescription> CatalogDescriptions { get; set; }

        internal DbSet<Menu> Menus { get; set; }

        internal DbSet<Service> Services { get; set; }

        internal DbSet<Provider> Providers { get; set; }

        internal DbSet<Tenant> Tenants { get; set; }

        internal DbSet<Company> Companies { get; set; }

        public ConfigurationsDbContext(DbContextOptions<ConfigurationsDbContext> options, IMultiTenantContextAccessor multiTenantContextAccessor, IConfiguration configuration, IWebHostEnvironment env) : base(options, multiTenantContextAccessor, configuration, env) { }

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

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
