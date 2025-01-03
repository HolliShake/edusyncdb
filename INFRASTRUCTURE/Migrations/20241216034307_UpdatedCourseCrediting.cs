using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCourseCrediting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpecializationChairs_UserId",
                table: "SpecializationChairs");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTeachers_ScheduleId",
                table: "ScheduleTeachers");

            migrationBuilder.AlterColumn<string>(
                name: "EvaluatedByUserId",
                table: "CourseCreditings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreditedDateTime",
                table: "CourseCreditings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CourseCreditings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationChairs_UserId",
                table: "SpecializationChairs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeachers_ScheduleId_TeacherUserId",
                table: "ScheduleTeachers",
                columns: new[] { "ScheduleId", "TeacherUserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpecializationChairs_UserId",
                table: "SpecializationChairs");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleTeachers_ScheduleId_TeacherUserId",
                table: "ScheduleTeachers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseCreditings");

            migrationBuilder.AlterColumn<string>(
                name: "EvaluatedByUserId",
                table: "CourseCreditings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreditedDateTime",
                table: "CourseCreditings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationChairs_UserId",
                table: "SpecializationChairs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeachers_ScheduleId",
                table: "ScheduleTeachers",
                column: "ScheduleId");
        }
    }
}
