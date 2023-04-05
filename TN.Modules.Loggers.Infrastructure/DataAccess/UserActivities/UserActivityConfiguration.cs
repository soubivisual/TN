using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Loggers.Domain.UserActivities.Aggregates;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.UserActivities
{
    internal sealed class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.ToTable(nameof(UserActivity));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(UserActivity)}{nameof(UserActivity.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TenantId);
            builder.Property(x => x.UserId);
            builder.Property(x => x.Channel).HasMaxLength(128);
            builder.Property(x => x.Action).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Detail).IsRequired().HasMaxLength(2048);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Ip).HasMaxLength(32);
            builder.Property(x => x.CoreProcessId);
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
