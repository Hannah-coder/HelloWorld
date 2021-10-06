using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace API.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MerchandiseFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    NumberRecordsReturned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandiseFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Page_Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    URLSection1 = table.Column<string>(type: "text", nullable: true),
                    URLSection2 = table.Column<string>(type: "text", nullable: true),
                    Parameter1 = table.Column<string>(type: "text", nullable: true),
                    Parameter2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: true),
                    FilterCriteria = table.Column<string>(type: "text", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberRecordsReturned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Response = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Uptime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RuntimeVersion = table.Column<string>(type: "text", nullable: true),
                    OSVersion = table.Column<string>(type: "text", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Start = table.Column<DateTime>(type: "datetime", nullable: false),
                    End = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Start_Time = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    End_Time = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    PageLoadTime = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSession_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageSession_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageSession_PageId",
                table: "PageSession",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSession_SessionId",
                table: "PageSession",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchandiseFilter");

            migrationBuilder.DropTable(
                name: "PageSession");

            migrationBuilder.DropTable(
                name: "PageView");

            migrationBuilder.DropTable(
                name: "PetFilter");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "ServerInformation");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
