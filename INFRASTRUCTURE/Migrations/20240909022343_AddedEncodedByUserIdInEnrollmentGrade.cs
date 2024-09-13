using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedEncodedByUserIdInEnrollmentGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradingInput",
                table: "EnrollmentGrades");

            migrationBuilder.AlterColumn<int>(
                name: "GradeInputId",
                table: "EnrollmentGrades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedByUserId",
                table: "EnrollmentGrades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGrades_EncodedByUserId",
                table: "EnrollmentGrades",
                column: "EncodedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades",
                column: "EncodedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades");

            migrationBuilder.DropIndex(
                name: "IX_EnrollmentGrades_EncodedByUserId",
                table: "EnrollmentGrades");

            migrationBuilder.DropColumn(
                name: "EncodedByUserId",
                table: "EnrollmentGrades");

            migrationBuilder.AlterColumn<int>(
                name: "GradeInputId",
                table: "EnrollmentGrades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GradingInput",
                table: "EnrollmentGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
