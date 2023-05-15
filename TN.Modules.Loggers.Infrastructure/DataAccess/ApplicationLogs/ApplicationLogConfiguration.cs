﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates;
using TN.Modules.Loggers.Domain.ApplicationLogs.ValueObjects;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.ApplicationLogs
{
    internal sealed class ApplicationLogConfiguration : IEntityTypeConfiguration<ApplicationLog>
    {
        public void Configure(EntityTypeBuilder<ApplicationLog> builder)
        {
            builder.ToTable(nameof(ApplicationLog));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(ApplicationLog)}{nameof(ApplicationLog.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TenantId);
            builder.Property(x => x.UserId);
            builder.Property(x => x.Channel).HasMaxLength(128);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(64).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.ClassName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.MethodName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Key).HasMaxLength(64);
            builder.Property(x => x.Value).HasMaxLength(128);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Ip).HasMaxLength(32);
            builder.Property(x => x.CoreProcessId);
            builder.Property(x => x.Message).HasMaxLength(4096).IsRequired();

            builder.HasData(new ApplicationLog(
                1,
                1, 
                1, 
                "ApplicationLogModule", 
                ApplicationLogType.Info, 
                "ClassName", 
                "MethodName", 
                "Key", 
                "Value",
                new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), 
                "::1", 
                Guid.NewGuid(), 
                "Test de ApplicationLog"),
                new ApplicationLog(
                2,
                2,
                1,
                "ApplicationLogModule",
                ApplicationLogType.Info,
                "ClassName",
                "MethodName",
                "Key",
                "Value",
                new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                "::1",
                Guid.NewGuid(),
                "Test de ApplicationLog"));
        }
    }
}
