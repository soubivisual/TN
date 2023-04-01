using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.TraceLogs
{
    internal sealed class TraceLogConfiguration : IEntityTypeConfiguration<TraceLog>
    {
        public void Configure(EntityTypeBuilder<TraceLog> builder)
        {
            builder.ToTable(nameof(TraceLog));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.TenantId);
            builder.Property(x => x.UserId);
            builder.Property(x => x.Channel).HasMaxLength(128);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(64);
            builder.Property(x => x.ClassName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.MethodName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Key).HasMaxLength(64);
            builder.Property(x => x.Value).HasMaxLength(128);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Ip).HasMaxLength(32);
            builder.Property(x => x.CoreProcessId);
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
