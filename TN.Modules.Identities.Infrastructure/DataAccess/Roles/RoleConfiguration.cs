using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Identities.Domain.Roles.Aggregates;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Roles
{
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(Role)}{nameof(Role.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
    }
}
