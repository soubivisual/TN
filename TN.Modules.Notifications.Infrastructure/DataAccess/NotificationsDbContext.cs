using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance;
using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;

namespace TN.Modules.Notifications.Infrastructure.DataAccess
{
    internal class NotificationsDbContext : DbContext
    {
        internal DbSet<Notification> Notifications { get; set; }

        private readonly string _schemaName;

        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options)
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
        }
    }
}
