using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedScheduleAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "GeneratedSections");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_RoomId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DaySchedule",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TimeScheduleIn",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TimeScheduleOut",
                table: "Schedules");

            migrationBuilder.CreateTable(
                name: "ScheduleAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaySchedule = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeScheduleIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeScheduleOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleAssignments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleAssignments_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAssignments_RoomId",
                table: "ScheduleAssignments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAssignments_ScheduleId",
                table: "ScheduleAssignments",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleAssignments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DaySchedule",
                table: "Schedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeScheduleIn",
                table: "Schedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeScheduleOut",
                table: "Schedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneratedSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumDetailId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    SectionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                        column: x => x.CurriculumDetailId,
                        principalTable: "CurriculumDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedSections_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RoomId",
                table: "Schedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedSections_CurriculumDetailId",
                table: "GeneratedSections",
                column: "CurriculumDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedSections_CycleId",
                table: "GeneratedSections",
                column: "CycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
