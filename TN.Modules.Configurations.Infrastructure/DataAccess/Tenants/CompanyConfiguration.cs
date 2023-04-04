using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Tenants.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Tenants
{
    internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Metadata);

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
