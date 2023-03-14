using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "identities");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "identities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentificationTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Identification = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EditedUserId = table.Column<int>(type: "integer", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "identities",
                table: "User",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "EditedDate", "EditedUserId", "Email", "Identification", "IdentificationTypeId", "Name", "Phone", "StatusId", "TypeId", "Username" },
                values: new object[] { 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "dsanabria@teledolar.com", "100010001", new Guid("99f7c8f3-6ba8-4090-aae8-55510bda7b26"), "Administrador", "88778573", new Guid("f80235c6-6de1-4384-ac74-d871a5f5d062"), new Guid("74af5517-75d7-4ea4-9a98-f0c011167a59"), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "identities");
        }
    }
}
