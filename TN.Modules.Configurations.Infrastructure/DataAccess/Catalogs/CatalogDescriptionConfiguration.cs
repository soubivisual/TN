using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Catalogs.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Catalogs
{
    internal sealed class CatalogDescriptionConfiguration : IEntityTypeConfiguration<CatalogDescription>
    {
        public void Configure(EntityTypeBuilder<CatalogDescription> builder)
        {
            builder.ToTable(nameof(CatalogDescription));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(CatalogDescription)}{nameof(CatalogDescription.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Type).IsRequired().HasMaxLength(64).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Int1).HasMaxLength(128);
            builder.Property(x => x.Int2).HasMaxLength(128);
            builder.Property(x => x.Nvarchar1).HasMaxLength(128);
            builder.Property(x => x.Nvarchar2).HasMaxLength(128);
            builder.Property(x => x.Nvarchar3).HasMaxLength(128);
            builder.Property(x => x.Nvarchar4).HasMaxLength(128);
            builder.Property(x => x.Nvarchar5).HasMaxLength(128);
            builder.Property(x => x.Bool1).HasMaxLength(128);
            builder.Property(x => x.Decimal1).HasMaxLength(128);
            builder.Property(x => x.Decimal2).HasMaxLength(128);

            builder.HasData(
                new CatalogDescription(1, "Currency", null, null, "Código ISO 4217", "Símbolo", null, null, null, null, null, null)
                );
        }
    }
}
