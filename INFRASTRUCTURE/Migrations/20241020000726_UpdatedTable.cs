using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDateTime",
                table: "ScheduleAttendances");

            migrationBuilder.DropColumn(
                name: "InLatitude",
                table: "ScheduleAttendances");

            migrationBuilder.DropColumn(
                name: "InLongitude",
                table: "ScheduleAttendances");

            migrationBuilder.RenameColumn(
                name: "OutLongitude",
                table: "ScheduleAttendances",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "OutLatitude",
                table: "ScheduleAttendances",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "CheckOutDateTime",
                table: "ScheduleAttendances",
                newName: "AttendanceDateTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsTimeIn",
                table: "ScheduleAttendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeScheduleOut",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeScheduleIn",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DaySchedule",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTimeIn",
                table: "ScheduleAttendances");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "ScheduleAttendances",
                newName: "OutLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "ScheduleAttendances",
                newName: "OutLatitude");

            migrationBuilder.RenameColumn(
                name: "AttendanceDateTime",
                table: "ScheduleAttendances",
                newName: "CheckOutDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDateTime",
                table: "ScheduleAttendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "InLatitude",
                table: "ScheduleAttendances",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InLongitude",
                table: "ScheduleAttendances",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeScheduleOut",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeScheduleIn",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DaySchedule",
                table: "ScheduleAssignments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
