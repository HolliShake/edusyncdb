using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnYearLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentDateTime",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "YearLEvel",
                table: "Enrollments",
                newName: "YearLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearLevel",
                table: "Enrollments",
                newName: "YearLEvel");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentDateTime",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
