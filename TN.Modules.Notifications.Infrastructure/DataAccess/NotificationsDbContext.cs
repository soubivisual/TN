using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance.Database;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;

namespace TN.Modules.Notifications.Infrastructure.DataAccess
{
    internal class NotificationsDbContext : DbContextBase
    {
        internal DbSet<Notification> Notifications { get; set; }

        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options, IMultiTenantContextAccessor multiTenantContextAccessor, IConfiguration configuration, IWebHostEnvironment env) : base(options, multiTenantContextAccessor, configuration, env) { }

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
