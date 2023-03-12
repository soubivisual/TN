using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TN.Modules.IdentitiesInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "identity",
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
                schema: "identity",
                table: "User",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "EditedDate", "EditedUserId", "Email", "Identification", "IdentificationTypeId", "Name", "Phone", "StatusId", "TypeId", "Username" },
                values: new object[] { 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "dsanabria@teledolar.com", "100010001", new Guid("200c7177-3855-4079-b604-95f8486cb216"), "Administrador", "88778573", new Guid("90dd8dba-552e-4bb3-a37e-f2ac348d72b2"), new Guid("1592ed8e-ed9f-4484-9f4a-4e53151f6803"), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "identity");
        }
    }
}
