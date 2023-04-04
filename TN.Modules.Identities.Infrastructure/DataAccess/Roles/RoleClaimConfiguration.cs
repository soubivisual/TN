﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN.Modules.Identities.Domain.Roles.Aggregates;
using TN.Modules.Identities.Domain.Roles.Entities;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Roles
{
    internal sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable(nameof(RoleClaim));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.RoleId).IsRequired().HasConversion(x => x.Value, y => new(y));
            builder.Property(x => x.ClaimId).IsRequired().HasConversion(x => x.Value, y => new(y));

            builder.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId);
            builder.HasOne<Claim>().WithMany().HasForeignKey(x => x.ClaimId);
        }
    }
}
