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

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
    }
}
