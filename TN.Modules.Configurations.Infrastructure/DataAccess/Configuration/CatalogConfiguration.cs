using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Catalogs.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Configuration
{
    internal sealed class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable(nameof(Catalog));

            builder.HasKey(x => x.Id);

            builder.Property(q => q.Id).HasConversion(q => q.Value, q => new(q));
            builder.Property(q => q.Type).IsRequired().HasConversion(q => q.Value, q => new(q));
            builder.Property(q => q.Value).IsRequired();
            builder.Property(q => q.Editable).IsRequired();
            builder.Property(q => q.Enabled).IsRequired();
            builder.Property(q => q.Int1);
            builder.Property(q => q.Int2);
            builder.Property(q => q.Nvarchar1).HasMaxLength(512);
            builder.Property(q => q.Nvarchar2).HasMaxLength(512);
            builder.Property(q => q.Nvarchar3).HasMaxLength(512);
            builder.Property(q => q.Nvarchar4).HasMaxLength(512);
            builder.Property(q => q.Nvarchar5).HasMaxLength(512);
            builder.Property(q => q.Bool1);
            builder.Property(q => q.Decimal1).HasPrecision(18, 2);
            builder.Property(q => q.Decimal2).HasPrecision(18, 2);

            builder.HasData(
                // General Status
                new Catalog(Guid.NewGuid(), "GeneralStatus", "Activo", false, true),
                new Catalog(Guid.NewGuid(), "GeneralStatus", "Inactivo", false, true),
                // Currencies
                new Catalog(Guid.NewGuid(), "Currency", "Colones", false, true, null, null, "CRC", "₡", null, null, null, null, null, null),
                new Catalog(Guid.NewGuid(), "Currency", "Dólares", false, true, null, null, "USD", "$", null, null, null, null, null, null)
                );
        }
    }
}
