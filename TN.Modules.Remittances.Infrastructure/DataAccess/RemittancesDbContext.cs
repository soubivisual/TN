using Microsoft.EntityFrameworkCore;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Infrastructure.DataAccess
{
    internal class RemittancesDbContext : DbContext
    {
        internal DbSet<Remittance> Remittances { get; set; }

        private readonly string _schemaName;

        public RemittancesDbContext(DbContextOptions<RemittancesDbContext> options) : base(options)
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
