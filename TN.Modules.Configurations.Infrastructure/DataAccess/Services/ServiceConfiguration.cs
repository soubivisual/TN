using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Configurations.Domain.Services.Aggregates;
using TN.Modules.Configurations.Domain.Services.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Services
{
    internal sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service));

            builder.HasKey(x => x.Id);

            builder.HasOne<Provider>().WithMany().HasForeignKey(x => x.ProviderId);

            builder.Property(x => x.Id).HasColumnName($"{nameof(Service)}{nameof(Service.Id)}").HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.ProviderId).IsRequired().HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.TermsAndConditions);
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Metadata);

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne<Provider>().WithMany().HasForeignKey(x => x.ProviderId);
        }
    }
}
