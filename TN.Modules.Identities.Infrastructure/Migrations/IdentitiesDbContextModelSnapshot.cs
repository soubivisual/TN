﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TN.Modules.Identities.Infrastructure.DataAccess;

#nullable disable

namespace TN.Modules.Identities.Infrastructure.Migrations
{
    [DbContext(typeof(IdentitiesDbContext))]
    partial class IdentitiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identities")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TN.Modules.Identities.Domain.Roles.Aggregates.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Role", "Identities");
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Roles.Entities.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClaimId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Claim", "Identities");
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Roles.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleClaimId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClaimId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", "Identities");
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Aggregates.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<Guid>("IdentificationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("User", "Identities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "dsanabria@teledolar.com",
                            Identification = "100010001",
                            IdentificationTypeId = new Guid("6e575e2b-d840-4adf-a139-e63c1fb90b69"),
                            Name = "Administrador",
                            Phone = "88778573",
                            StatusId = new Guid("73bb6bda-4687-44b3-93a5-03ba83280efc"),
                            TypeId = new Guid("306d9e4b-bc0b-40d7-bd35-604b0a7b26d5"),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserLoginId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("LoginProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", "Identities");
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserRoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", "Identities");
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Roles.Entities.RoleClaim", b =>
                {
                    b.HasOne("TN.Modules.Identities.Domain.Roles.Entities.Claim", null)
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TN.Modules.Identities.Domain.Roles.Aggregates.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Entities.UserLogin", b =>
                {
                    b.HasOne("TN.Modules.Identities.Domain.Users.Aggregates.User", null)
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Entities.UserRole", b =>
                {
                    b.HasOne("TN.Modules.Identities.Domain.Roles.Aggregates.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TN.Modules.Identities.Domain.Users.Aggregates.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TN.Modules.Identities.Domain.Users.Aggregates.User", b =>
                {
                    b.Navigation("UserLogins");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
