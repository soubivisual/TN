using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Tenants.Aggregates;
using TN.Modules.Configurations.Domain.Tenants.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Tenants
{
    internal sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable(nameof(Tenant));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.CompanyId).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Metadata);

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne<Company>().WithMany().HasForeignKey(x => x.CompanyId);
        }
    }
}
