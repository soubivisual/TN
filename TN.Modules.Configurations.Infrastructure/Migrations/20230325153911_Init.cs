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
                    Decimal2 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Configurations",
                table: "Catalog",
                columns: new[] { "Id", "Bool1", "Decimal1", "Decimal2", "Editable", "Enabled", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("060cf618-dd69-4d9c-985e-f384690b4d63"), null, null, null, false, true, null, null, "CRC", "₡", null, null, null, "Currency", "Colones" },
                    { new Guid("12465b52-29b3-4a84-be56-37e0350711e8"), null, null, null, false, true, null, null, null, null, null, null, null, "GeneralStatus", "Activo" },
                    { new Guid("1c32f757-49f7-41fb-9134-3aa0e45b7784"), null, null, null, false, true, null, null, null, null, null, null, null, "GeneralStatus", "Inactivo" },
                    { new Guid("93743f52-587c-4a79-a6ae-bcbd4a9af888"), null, null, null, false, true, null, null, "USD", "$", null, null, null, "Currency", "Dólares" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "Configurations");
        }
    }
}
