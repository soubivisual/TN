using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.Modules.Identities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identities");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedUserId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedUserId = table.Column<int>(type: "int", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identities",
                table: "User",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "EditedDate", "EditedUserId", "Email", "Identification", "IdentificationTypeId", "Name", "Phone", "StatusId", "TypeId", "Username" },
                values: new object[] { 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "dsanabria@teledolar.com", "100010001", new Guid("54173bd8-4fa4-4e29-a916-a3c9ea5d6cd3"), "Administrador", "88778573", new Guid("a38c4fa8-7817-4ab8-9b75-13cd6479eaa8"), new Guid("92790c13-b48d-4f52-9507-43d9a43030db"), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "Identities");
        }
    }
}
