using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Domain.Users.Aggregates;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Users
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // INFO: El esquema se estará especificando desde el DbContext, pero se deja esta línea como referencia
            //builder.ToTable(nameof(User), "identity");
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            // INFO: Es posible obtener el nombre de una propiedad como un string y cambiarle el nombre que tendrá a nivel de base de datos,
            // por ejemplo, si tenemos la propiedad: private string _identificationTypeId;
            // en este caso se utilizará la nomenclatura PascalCase, por lo que no será necesario, sin embargo, se deja esta línea como referencia
            //builder.Property<string>("_identificationTypeId").HasColumnName("IdentificationTypeId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName($"{nameof(User)}{nameof(User.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.IdentificationTypeId).IsRequired();
            builder.Property(x => x.Identification).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Username).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(64);
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();

            //builder.HasMany<UserRole>(x => x.UserRoles).WithOne().HasForeignKey(x => x.UserId);

            builder.HasData(new User(
                1,
                Guid.NewGuid(),
                "100010001",
                "Administrador",
                "admin",
                "dsanabria@teledolar.com",
                "88778573",
                Guid.NewGuid(),
                Guid.NewGuid(),
                null,
                new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc)));
        }
    }
}
