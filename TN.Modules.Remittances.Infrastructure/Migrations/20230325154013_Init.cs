using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.Modules.Remittances.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Remittances");

            migrationBuilder.CreateTable(
                name: "Remittance",
                schema: "Remittances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SenderIdentification = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ReceiverIdentification = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SenderFullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ReceiverFullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SenderCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReceiverAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remittance", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remittance",
                schema: "Remittances");
        }
    }
}
