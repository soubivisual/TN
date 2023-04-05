using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Infrastructure.DataAccess.Remittances
{
    internal sealed class RemittanceConfiguration : IEntityTypeConfiguration<Remittance>
    {
        public void Configure(EntityTypeBuilder<Remittance> builder)
        {
            builder.ToTable(nameof(Remittance));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(Remittance)}{nameof(Remittance.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TenantId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ServiceId).IsRequired();
            builder.Property(x => x.SenderIdentification).HasMaxLength(128);
            builder.Property(x => x.ReceiverIdentification).HasMaxLength(128);
            builder.Property(x => x.SenderFullName).HasMaxLength(256);
            builder.Property(x => x.ReceiverFullName).HasMaxLength(256);
            builder.Property(x => x.SenderCurrencyId);
            builder.Property(x => x.ReceiverCurrencyId);
            builder.Property(x => x.SenderAmount).HasPrecision(18, 2);
            builder.Property(x => x.ReceiverAmount).HasPrecision(18, 2);
            builder.Property(x => x.ExchangeRate).HasPrecision(18, 8);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.CoreProcessId).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(512);
            builder.Property(x => x.Data);
        }
    }
}
