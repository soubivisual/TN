using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Identities.Domain.Roles.Entities;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Roles
{
    internal sealed class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable(nameof(Claim));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(Claim)}{nameof(Claim.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Type).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(256);
        }
    }
}
