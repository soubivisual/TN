using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Domain.Users.Entities;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Users
{
    internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable(nameof(UserLogin));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(UserLogin)}{nameof(UserLogin.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LoginProviderId).IsRequired();
            builder.Property(x => x.ProviderKey).IsRequired().HasMaxLength(256);

            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
