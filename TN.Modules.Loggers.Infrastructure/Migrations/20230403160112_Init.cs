﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraceLog",
                schema: "Loggers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraceLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivity",
                schema: "Loggers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CoreProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivity", x => x.Id);
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
