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
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
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
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Configurations",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Configurations",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Configurations",
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Configurations",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "Catalog",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "Bool1", "Decimal1", "Decimal2", "Editable", "EditedDate", "EditedUserId", "Enabled", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("0c043d8c-b11e-4530-84cb-e1a145061cae"), null, null, null, null, null, false, null, null, true, null, null, null, null, null, null, null, "GeneralStatus", "Inactivo" },
                    { new Guid("c0e93895-e330-4405-a7f3-55e62163a82d"), null, null, null, null, null, false, null, null, true, null, null, "CRC", "₡", null, null, null, "Currency", "Colones" },
                    { new Guid("c9f498d5-e643-4fcc-a569-5a8a6e9b5627"), null, null, null, null, null, false, null, null, true, null, null, "USD", "$", null, null, null, "Currency", "Dólares" },
                    { new Guid("f11658c6-5c8d-45c9-bf92-3c9d827d282b"), null, null, null, null, null, false, null, null, true, null, null, null, null, null, null, null, "GeneralStatus", "Activo" }
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "CatalogDescription",
                columns: new[] { "Id", "Bool1", "Decimal1", "Decimal2", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type" },
                values: new object[] { 1, null, null, null, null, null, "Código ISO 4217", "Símbolo", null, null, null, "Currency" });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "Configurations",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ServiceId",
                schema: "Configurations",
                table: "Menu",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_TenantId",
                schema: "Configurations",
                table: "Menu",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProviderId",
                schema: "Configurations",
                table: "Service",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_CompanyId",
                schema: "Configurations",
                table: "Tenant",
                column: "CompanyId");
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

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Configurations");
        }
    }
}
