using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TN.Modules.Configurations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Configurations");

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editable = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Int1 = table.Column<int>(type: "int", nullable: true),
                    Int2 = table.Column<int>(type: "int", nullable: true),
                    Nvarchar1 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Nvarchar2 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Nvarchar3 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Nvarchar4 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Nvarchar5 = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Bool1 = table.Column<bool>(type: "bit", nullable: true),
                    Decimal1 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Decimal2 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogDescription",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Int1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Int2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Nvarchar1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Nvarchar2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Nvarchar3 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Nvarchar4 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Nvarchar5 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Bool1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Decimal1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Decimal2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogDescription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    Server = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timeout = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Configurations",
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "Catalog",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "Bool1", "Decimal1", "Decimal2", "Editable", "EditedDate", "EditedUserId", "Enabled", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("07190d8f-fb8e-44d4-99e4-3288d2875296"), null, null, null, null, null, false, null, null, true, null, null, "CRC", "₡", null, null, null, "Currency", "Colones" },
                    { new Guid("27409b8e-63f8-4d01-a83c-acd6a5186974"), null, null, null, null, null, false, null, null, true, null, null, null, null, null, null, null, "GeneralStatus", "Inactivo" },
                    { new Guid("86dd6e3d-d369-4e69-91dc-f8c190836d36"), null, null, null, null, null, false, null, null, true, null, null, null, null, null, null, null, "GeneralStatus", "Activo" },
                    { new Guid("be8b58f0-c537-4995-a351-4db2b398cfbc"), null, null, null, null, null, false, null, null, true, null, null, "USD", "$", null, null, null, "Currency", "Dólares" }
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "CatalogDescription",
                columns: new[] { "Id", "Bool1", "Decimal1", "Decimal2", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type" },
                values: new object[] { 1, null, null, null, null, null, "Código ISO 4217", "Símbolo", null, null, null, "Currency" });

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProviderId",
                schema: "Configurations",
                table: "Service",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "CatalogDescription",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "Configurations");

            migrationBuilder.DropTable(
                name: "Provider",
                schema: "Configurations");
        }
    }
}
