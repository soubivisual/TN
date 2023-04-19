using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;

namespace TN.Modules.Notifications.Infrastructure.DataAccess.Notifications
{
    internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable(nameof(Notification));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(Notification)}{nameof(Notification.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TenantId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CallbackUrl).HasMaxLength(1024);
            builder.Property(x => x.Read).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.ReadDate);
            builder.Property(x => x.ExpirationDate);
            builder.Property(x => x.CoreProcessId).IsRequired();
        }
    }
}
