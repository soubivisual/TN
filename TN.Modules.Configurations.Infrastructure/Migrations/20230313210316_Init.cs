using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.Modules.Configurations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "configurations");

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Editable = table.Column<bool>(type: "boolean", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Int1 = table.Column<int>(type: "integer", nullable: true),
                    Int2 = table.Column<int>(type: "integer", nullable: true),
                    Nvarchar1 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Nvarchar2 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Nvarchar3 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Nvarchar4 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Nvarchar5 = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Bool1 = table.Column<bool>(type: "boolean", nullable: true),
                    Decimal1 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Decimal2 = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "configurations",
                table: "Catalog",
                columns: new[] { "Id", "Bool1", "Decimal1", "Decimal2", "Editable", "Enabled", "Int1", "Int2", "Nvarchar1", "Nvarchar2", "Nvarchar3", "Nvarchar4", "Nvarchar5", "Type", "Value" },
                values: new object[] { new Guid("3f7c9744-08a1-431b-a916-2bb212b97df1"), null, null, null, false, true, null, null, null, null, null, null, null, "GeneralStatus", "Activo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "configurations");
        }
    }
}
