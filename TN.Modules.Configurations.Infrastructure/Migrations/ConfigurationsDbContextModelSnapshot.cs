﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TN.Modules.Configurations.Infrastructure.DataAccess;

#nullable disable

namespace TN.Modules.Configurations.Infrastructure.Migrations
{
    [DbContext(typeof(ConfigurationsDbContext))]
    partial class ConfigurationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Configurations")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Catalogs.Aggregates.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<bool?>("Bool1")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Decimal1")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Decimal2")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Editable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int?>("Int1")
                        .HasColumnType("int");

                    b.Property<int?>("Int2")
                        .HasColumnType("int");

                    b.Property<string>("Nvarchar1")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Nvarchar2")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Nvarchar3")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Nvarchar4")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Nvarchar5")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalog", "Configurations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f11658c6-5c8d-45c9-bf92-3c9d827d282b"),
                            Editable = false,
                            Enabled = true,
                            Type = "GeneralStatus",
                            Value = "Activo"
                        },
                        new
                        {
                            Id = new Guid("0c043d8c-b11e-4530-84cb-e1a145061cae"),
                            Editable = false,
                            Enabled = true,
                            Type = "GeneralStatus",
                            Value = "Inactivo"
                        },
                        new
                        {
                            Id = new Guid("c0e93895-e330-4405-a7f3-55e62163a82d"),
                            Editable = false,
                            Enabled = true,
                            Nvarchar1 = "CRC",
                            Nvarchar2 = "₡",
                            Type = "Currency",
                            Value = "Colones"
                        },
                        new
                        {
                            Id = new Guid("c9f498d5-e643-4fcc-a569-5a8a6e9b5627"),
                            Editable = false,
                            Enabled = true,
                            Nvarchar1 = "USD",
                            Nvarchar2 = "$",
                            Type = "Currency",
                            Value = "Dólares"
                        });
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Catalogs.Entities.CatalogDescription", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Bool1")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Decimal1")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Decimal2")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Int1")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Int2")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nvarchar1")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nvarchar2")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nvarchar3")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nvarchar4")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nvarchar5")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatalogDescription", "Configurations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nvarchar1 = "Código ISO 4217",
                            Nvarchar2 = "Símbolo",
                            Type = "Currency"
                        });
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Menus.Aggregates.Menu", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<string>("ClaimId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TenantId");

                    b.ToTable("Menu", "Configurations");
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Services.Aggregates.Service", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TermsAndConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Service", "Configurations");
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Services.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Timeout")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Provider", "Configurations");
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Tenants.Aggregates.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Tenant", "Configurations");
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Tenants.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Company", "Configurations");
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Menus.Aggregates.Menu", b =>
                {
                    b.HasOne("TN.Modules.Configurations.Domain.Menus.Aggregates.Menu", null)
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TN.Modules.Configurations.Domain.Services.Aggregates.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TN.Modules.Configurations.Domain.Tenants.Aggregates.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Services.Aggregates.Service", b =>
                {
                    b.HasOne("TN.Modules.Configurations.Domain.Services.Entities.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TN.Modules.Configurations.Domain.Tenants.Aggregates.Tenant", b =>
                {
                    b.HasOne("TN.Modules.Configurations.Domain.Tenants.Entities.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
