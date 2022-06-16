using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDAPIChallenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyHours = table.Column<double>(type: "float", nullable: false),
                    CurrentHours = table.Column<double>(type: "float", nullable: false),
                    AircraftTasksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftTasks_AircraftTasksId",
                        column: x => x.AircraftTasksId,
                        principalTable: "AircraftTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AircraftTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogHours = table.Column<int>(type: "int", nullable: true),
                    IntervalMonths = table.Column<int>(type: "int", nullable: true),
                    IntervalHours = table.Column<int>(type: "int", nullable: true),
                    NextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AircraftTasksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AircraftTask_AircraftTasks_AircraftTasksId",
                        column: x => x.AircraftTasksId,
                        principalTable: "AircraftTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AircraftTasksId",
                table: "Aircrafts",
                column: "AircraftTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftTask_AircraftTasksId",
                table: "AircraftTask",
                column: "AircraftTasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "AircraftTask");

            migrationBuilder.DropTable(
                name: "AircraftTasks");
        }
    }
}
