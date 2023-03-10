// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TN.Modules.IdentitiesInfrastructure.DataAccess;

#nullable disable

namespace TN.Modules.Identities.Infrastructure.Migrations
{
    [DbContext(typeof(IdentitiesDbContext))]
    [Migration("20230313210359_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("identities")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TN.Modules.IdentitiesDomain.Users.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AddedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EditedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EditedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdentificationTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("User", "identities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "dsanabria@teledolar.com",
                            Identification = "100010001",
                            IdentificationTypeId = new Guid("99f7c8f3-6ba8-4090-aae8-55510bda7b26"),
                            Name = "Administrador",
                            Phone = "88778573",
                            StatusId = new Guid("f80235c6-6de1-4384-ac74-d871a5f5d062"),
                            TypeId = new Guid("74af5517-75d7-4ea4-9a98-f0c011167a59"),
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
