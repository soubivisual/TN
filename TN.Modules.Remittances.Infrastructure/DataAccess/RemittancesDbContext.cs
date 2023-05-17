using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Infrastructure.DataAccess
{
    internal class RemittancesDbContext : DbContextBase
    {
        internal DbSet<Remittance> Remittances { get; set; }

        public RemittancesDbContext(DbContextOptions<RemittancesDbContext> options, IMultiTenantContextAccessor multiTenantContextAccessor, IConfiguration configuration, IWebHostEnvironment env) : base(options, multiTenantContextAccessor, configuration, env) { }

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
