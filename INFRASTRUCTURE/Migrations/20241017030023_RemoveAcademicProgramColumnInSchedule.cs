using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAcademicProgramColumnInSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_AcademicProgramId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "AcademicProgramId",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AcademicProgramId",
                table: "Schedules",
                column: "AcademicProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
