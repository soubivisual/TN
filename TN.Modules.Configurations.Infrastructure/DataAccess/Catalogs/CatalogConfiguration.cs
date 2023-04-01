using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Catalogs
{
    internal sealed class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable(nameof(Catalog));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Type).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Editable).IsRequired();
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.Int1);
            builder.Property(x => x.Int2);
            builder.Property(x => x.Nvarchar1).HasMaxLength(512);
            builder.Property(x => x.Nvarchar2).HasMaxLength(512);
            builder.Property(x => x.Nvarchar3).HasMaxLength(512);
            builder.Property(x => x.Nvarchar4).HasMaxLength(512);
            builder.Property(x => x.Nvarchar5).HasMaxLength(512);
            builder.Property(x => x.Bool1);
            builder.Property(x => x.Decimal1).HasPrecision(18, 2);
            builder.Property(x => x.Decimal2).HasPrecision(18, 2);

            builder.Property(x => x.RowVersion).IsRowVersion();

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
