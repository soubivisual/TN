using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Menus.Aggregates;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Menus
{
    internal sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable(nameof(Menu));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TenantId).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.ParentId).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.ServiceId).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Icon);
            builder.Property(x => x.ClaimId);
            builder.Property(x => x.StatusId).IsRequired();
        }
    }
}
