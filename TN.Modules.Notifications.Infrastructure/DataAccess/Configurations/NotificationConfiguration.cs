using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;

namespace TN.Modules.Notifications.Infrastructure.DataAccess.Configurations
{
    internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable(nameof(Notification));

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id).ValueGeneratedOnAdd().HasConversion(q => q.Value, q => new(q));
            builder.Property(q => q.TenantId).IsRequired();
            builder.Property(q => q.UserId).IsRequired();
            builder.Property(q => q.TypeId).IsRequired();
            builder.Property(q => q.StatusId).IsRequired();
            builder.Property(q => q.Priority).IsRequired();
            builder.Property(q => q.Title).IsRequired().HasMaxLength(128);
            builder.Property(q => q.Text).IsRequired().HasMaxLength(256);
            builder.Property(q => q.CallbackUrl).HasMaxLength(1024);
            builder.Property(q => q.Read).IsRequired();
            builder.Property(q => q.Date).IsRequired();
            builder.Property(q => q.ReadDate);
            builder.Property(q => q.ExpirationDate);
            builder.Property(q => q.CoreProcessId).IsRequired();
        }
    }
}
