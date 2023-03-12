﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TN.Modules.Configurations.Infrastructure.DataAccess;

#nullable disable

namespace TN.Modules.Configurations.Infrastructure.Migrations
{
    [DbContext(typeof(ConfigurationsDbContext))]
    partial class ConfigurationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("configuration")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Catalogs.Entities.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool?>("Bool1")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Decimal1")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal?>("Decimal2")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<bool>("Editable")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<int?>("Int1")
                        .HasColumnType("integer");

                    b.Property<int?>("Int2")
                        .HasColumnType("integer");

                    b.Property<string>("Nvarchar1")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Nvarchar2")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Nvarchar3")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Nvarchar4")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Nvarchar5")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Catalog", "configuration");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22c26cbf-bc56-414b-a5ab-ce14a7620c26"),
                            Editable = false,
                            Enabled = true,
                            Type = "GeneralStatus",
                            Value = "Activo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
