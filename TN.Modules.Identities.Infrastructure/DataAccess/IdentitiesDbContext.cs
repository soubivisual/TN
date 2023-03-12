using Microsoft.EntityFrameworkCore;
using TN.Modules.IdentitiesDomain.Users.Entities;

namespace TN.Modules.IdentitiesInfrastructure.DataAccess
{
    internal class IdentitiesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public IdentitiesDbContext(DbContextOptions<IdentitiesDbContext> options) : base(options) { }

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

            modelBuilder.HasDefaultSchema("identities");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // INFO: De esta forma se puede aplicar la configuración de cada entidad de forma manual en lugar de tomarlas del Assembly
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
