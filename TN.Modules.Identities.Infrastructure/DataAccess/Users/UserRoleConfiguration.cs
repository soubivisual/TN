using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Domain.Users.Aggregates;
using TN.Modules.Identities.Domain.Users.Entities;
using TN.Modules.Identities.Domain.Roles.Aggregates;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Users
{
    internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.UserId).IsRequired().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.RoleId).IsRequired().HasConversion(x => x.Value, y => new(y));

            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId);
        }
    }
}
