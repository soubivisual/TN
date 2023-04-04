using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Domain.Users.Entities;
using TN.Modules.Identities.Domain.Users.Aggregates;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Users
{
    internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable(nameof(UserLogin));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LoginProviderId).IsRequired();
            builder.Property(x => x.ProviderKey).IsRequired().HasMaxLength(256);

            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
