using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedUpdateToSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CourseId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumDetailId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CurriculumDetailId",
                table: "Schedules",
                column: "CurriculumDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_CurriculumDetails_CurriculumDetailId",
                table: "Schedules",
                column: "CurriculumDetailId",
                principalTable: "CurriculumDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_CurriculumDetails_CurriculumDetailId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CurriculumDetailId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CurriculumDetailId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CourseId",
                table: "Schedules",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
