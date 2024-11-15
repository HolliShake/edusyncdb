using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferenceToScheduleTeacherFromEvaluationRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleTeacherId",
                table: "EvaluationRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationRatings_ScheduleTeacherId",
                table: "EvaluationRatings",
                column: "ScheduleTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatings_ScheduleTeachers_ScheduleTeacherId",
                table: "EvaluationRatings",
                column: "ScheduleTeacherId",
                principalTable: "ScheduleTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatings_ScheduleTeachers_ScheduleTeacherId",
                table: "EvaluationRatings");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationRatings_ScheduleTeacherId",
                table: "EvaluationRatings");

            migrationBuilder.DropColumn(
                name: "ScheduleTeacherId",
                table: "EvaluationRatings");
        }
    }
}
