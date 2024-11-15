using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedProgramChairTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicProgramChairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicProgramChairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicProgramChairs_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicProgramChairs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgramChairs_AcademicProgramId",
                table: "AcademicProgramChairs",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgramChairs_UserId",
                table: "AcademicProgramChairs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicProgramChairs");
        }
    }
}
