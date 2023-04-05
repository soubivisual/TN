using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance;
using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Roles.Aggregates;
using TN.Modules.Identities.Domain.Roles.Entities;
using TN.Modules.Identities.Domain.Users.Aggregates;
using TN.Modules.Identities.Domain.Users.Entities;

namespace TN.Modules.Identities.Infrastructure.DataAccess
{
    internal class IdentitiesDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        internal DbSet<UserLogin> UserLogins { get; set; }

        internal DbSet<UserRole> UserRoles { get; set; }

        internal DbSet<Role> Roles { get; set; }

        internal DbSet<RoleClaim> RoleClaims { get; set; }

        internal DbSet<Claim> Claims { get; set; }

        private readonly string _schemaName;

        public IdentitiesDbContext(DbContextOptions<IdentitiesDbContext> options) : base(options) 
        {
            _schemaName = this.GetType().Name.Replace(nameof(DbContext), string.Empty);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConnectionStrings.Database), y => y.MigrationsHistoryTable("MigrationsHistory", _schemaName));
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveColumnType("varchar");
            configurationBuilder.Properties<ValueObjectBase<string>>().HaveColumnType("varchar");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(_schemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // INFO: De esta forma se puede aplicar la configuración de cada entidad de forma manual en lugar de tomarlas del Assembly
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Solución del Error: Introducing FOREIGN KEY constraint 'FK_XXXXX' on table 'XXX' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
