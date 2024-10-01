using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedDepartmentIdInGradingPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "GradingPeriods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradingPeriods_DepartmentId",
                table: "GradingPeriods",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingPeriods_Colleges_DepartmentId",
                table: "GradingPeriods",
                column: "DepartmentId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingPeriods_Colleges_DepartmentId",
                table: "GradingPeriods");

            migrationBuilder.DropIndex(
                name: "IX_GradingPeriods_DepartmentId",
                table: "GradingPeriods");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "GradingPeriods");
        }
    }
}
