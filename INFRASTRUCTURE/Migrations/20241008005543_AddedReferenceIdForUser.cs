using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferenceIdForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookScores_GradeBookItemDetailId",
                table: "GradeBookScores",
                column: "GradeBookItemDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookScores_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookScores",
                column: "GradeBookItemDetailId",
                principalTable: "GradeBookItemDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookScores_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookScores");

            migrationBuilder.DropIndex(
                name: "IX_GradeBookScores_GradeBookItemDetailId",
                table: "GradeBookScores");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Users");
        }
    }
}
