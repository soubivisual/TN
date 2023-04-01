using Microsoft.EntityFrameworkCore;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Infrastructure.DataAccess
{
    internal class RemittancesDbContext : DbContext
    {
        internal DbSet<Remittance> Remittances { get; set; }

        public RemittancesDbContext(DbContextOptions<RemittancesDbContext> options) : base(options) { }

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

            modelBuilder.HasDefaultSchema("Remittances");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
