using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCourseCreditColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings");

            migrationBuilder.DropIndex(
                name: "IX_CourseCreditings_OtherSchoolId",
                table: "CourseCreditings");

            migrationBuilder.DropColumn(
                name: "OtherSchoolId",
                table: "CourseCreditings");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_CreditedFromSchoolId",
                table: "CourseCreditings",
                column: "CreditedFromSchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_OtherSchools_CreditedFromSchoolId",
                table: "CourseCreditings",
                column: "CreditedFromSchoolId",
                principalTable: "OtherSchools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_OtherSchools_CreditedFromSchoolId",
                table: "CourseCreditings");

            migrationBuilder.DropIndex(
                name: "IX_CourseCreditings_CreditedFromSchoolId",
                table: "CourseCreditings");

            migrationBuilder.AddColumn<int>(
                name: "OtherSchoolId",
                table: "CourseCreditings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_OtherSchoolId",
                table: "CourseCreditings",
                column: "OtherSchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings",
                column: "OtherSchoolId",
                principalTable: "OtherSchools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
