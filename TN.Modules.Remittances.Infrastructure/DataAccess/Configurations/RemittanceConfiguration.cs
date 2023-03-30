using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Infrastructure.DataAccess.Configurations
{
    internal sealed class RemittanceConfiguration : IEntityTypeConfiguration<Remittance>
    {
        public void Configure(EntityTypeBuilder<Remittance> builder)
        {
            builder.ToTable(nameof(Remittance));

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id).ValueGeneratedOnAdd().HasConversion(q => q.Value, q => new(q));
            builder.Property(q => q.TenantId).IsRequired();
            builder.Property(q => q.UserId).IsRequired();
            builder.Property(q => q.ServiceId).IsRequired();
            builder.Property(q => q.SenderIdentification).HasMaxLength(128);
            builder.Property(q => q.ReceiverIdentification).HasMaxLength(128);
            builder.Property(q => q.SenderFullName).HasMaxLength(256);
            builder.Property(q => q.ReceiverFullName).HasMaxLength(256);
            builder.Property(q => q.SenderCurrencyId);
            builder.Property(q => q.ReceiverCurrencyId);
            builder.Property(q => q.SenderAmount).HasPrecision(18, 2);
            builder.Property(q => q.ReceiverAmount).HasPrecision(18, 2);
            builder.Property(q => q.ExchangeRate).HasPrecision(18, 8);
            builder.Property(q => q.Date).IsRequired();
            builder.Property(q => q.StatusId).IsRequired();
            builder.Property(q => q.CoreProcessId).IsRequired();
            builder.Property(q => q.Message).HasMaxLength(512);
            builder.Property(q => q.Data);
        }
    }
}
