using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TN.Modules.Loggers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Loggers");

            migrationBuilder.CreateTable(
                name: "ApplicationLog",
                schema: "Loggers",
                columns: table => new
                {
                    ApplicationLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    ClassName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    MethodName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.ApplicationLogId);
                });

            migrationBuilder.CreateTable(
                name: "TraceLog",
                schema: "Loggers",
                columns: table => new
                {
                    TraceLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    ClassName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    MethodName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraceLog", x => x.TraceLogId);
                });

            migrationBuilder.CreateTable(
                name: "UserActivity",
                schema: "Loggers",
                columns: table => new
                {
                    UserActivityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Action = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Detail = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivity", x => x.UserActivityId);
                });

            migrationBuilder.InsertData(
                schema: "Loggers",
                table: "ApplicationLog",
                columns: new[] { "ApplicationLogId", "Channel", "ClassName", "CoreProcessId", "Date", "Ip", "Key", "Message", "MethodName", "TenantId", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { 1L, "ApplicationLogModule", "ClassName", new Guid("fc6263a3-3dc0-4fd5-b2e8-e5e72c3e227d"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), "::1", "Key", "Test de ApplicationLog", "MethodName", 1, "Info", 1, "Value" },
                    { 2L, "ApplicationLogModule", "ClassName", new Guid("1b05722d-e4df-424b-8a64-627acbf98fbe"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), "::1", "Key", "Test de ApplicationLog", "MethodName", 2, "Info", 1, "Value" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLog",
                schema: "Loggers");

            migrationBuilder.DropTable(
                name: "TraceLog",
                schema: "Loggers");

            migrationBuilder.DropTable(
                name: "UserActivity",
                schema: "Loggers");
        }
    }
}
