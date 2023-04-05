using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Services.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Services
{
    internal sealed class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable(nameof(Provider));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName($"{nameof(Provider)}{nameof(Provider.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Username).HasMaxLength(128);
            builder.Property(x => x.Password).HasMaxLength(4096);
            builder.Property(x => x.Timeout);
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Metadata);

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
