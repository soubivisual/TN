using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Domain.Users.Entities;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // INFO: El esquema se estará especificando desde el DbContext, pero se deja esta línea como referencia
        //builder.ToTable(nameof(User), "identity");
        builder.ToTable(nameof(User));

        builder.HasKey(q => q.Id);

        // INFO: Es posible obtener el nombre de una propiedad como un string y cambiarle el nombre que tendrá a nivel de base de datos,
        // por ejemplo, si tenemos la propiedad: private string _identificationTypeId;
        // en este caso se utilizará la nomenclatura PascalCase, por lo que no será necesario, sin embargo, se deja esta línea como referencia
        //builder.Property<string>("_identificationTypeId").HasColumnName("IdentificationTypeId");
        builder.Property(q => q.Id).ValueGeneratedOnAdd().HasConversion(q => q.Value, q => new (q));
        builder.Property(q => q.IdentificationTypeId).IsRequired();
        builder.Property(q => q.Identification).IsRequired();
        builder.Property(q => q.Name).IsRequired().HasMaxLength(256).HasConversion(q => q.Value, q => new (q));
        builder.Property(q => q.Username).IsRequired().HasMaxLength(256);
        builder.Property(q => q.Email).IsRequired().HasMaxLength(256);
        builder.Property(q => q.Phone).IsRequired().HasMaxLength(64);
        builder.Property(q => q.TypeId).IsRequired();
        builder.Property(q => q.StatusId).IsRequired();

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
