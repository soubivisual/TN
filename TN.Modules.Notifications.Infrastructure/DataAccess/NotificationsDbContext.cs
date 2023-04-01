using Microsoft.EntityFrameworkCore;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;

namespace TN.Modules.Notifications.Infrastructure.DataAccess
{
    internal class NotificationsDbContext : DbContext
    {
        internal DbSet<Notification> Notifications { get; set; }

        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options) { }

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

            modelBuilder.HasDefaultSchema("Notifications");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
