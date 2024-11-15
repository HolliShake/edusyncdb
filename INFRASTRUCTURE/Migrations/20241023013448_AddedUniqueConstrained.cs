using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueConstrained : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AcademicProgramChairs_UserId",
                table: "AcademicProgramChairs");

            migrationBuilder.CreateTable(
                name: "CollegeDeans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeDeans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeDeans_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeDeans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgramChairs_UserId",
                table: "AcademicProgramChairs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollegeDeans_CollegeId",
                table: "CollegeDeans",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeDeans_UserId",
                table: "CollegeDeans",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeDeans");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgramChairs_UserId",
                table: "AcademicProgramChairs");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgramChairs_UserId",
                table: "AcademicProgramChairs",
                column: "UserId");
        }
    }
}
