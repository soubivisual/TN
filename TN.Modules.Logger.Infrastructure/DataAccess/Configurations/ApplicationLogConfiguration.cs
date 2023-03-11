using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Logger.Domain.ApplicationLogs.Entities;
using TN.Modules.Logger.Domain.ApplicationLogs.Enums;

namespace TN.Modules.Logger.Infrastructure.DataAccess.Configurations
{
    internal sealed class ApplicationLogConfiguration : IEntityTypeConfiguration<ApplicationLog>
    {
        public void Configure(EntityTypeBuilder<ApplicationLog> builder)
        {
            builder.ToTable(nameof(ApplicationLog));

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id).HasConversion(q => q.Value, q => new(q));
            builder.Property(q => q.TenantId);
            builder.Property(q => q.UserId);
            builder.Property(q => q.Channel).HasMaxLength(128);
            builder.Property(q => q.Type).IsRequired().HasMaxLength(64).HasConversion(q => q.ToString(), q => (ApplicationLogType)Enum.Parse(typeof(ApplicationLogType), q));
            builder.Property(q => q.ClassName).IsRequired().HasMaxLength(128);
            builder.Property(q => q.MethodName).IsRequired().HasMaxLength(256);
            builder.Property(q => q.Key).HasMaxLength(64);
            builder.Property(q => q.Value).HasMaxLength(128);
            builder.Property(q => q.Date).IsRequired();
            builder.Property(q => q.Ip).HasMaxLength(32);
            builder.Property(q => q.CoreProcessId);
            builder.Property(q => q.Message).IsRequired();
        }
    }
}
