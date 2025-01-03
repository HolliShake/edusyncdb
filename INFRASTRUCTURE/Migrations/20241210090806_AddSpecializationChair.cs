using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationChair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecializationChairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SFTrackSpecializationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationChairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecializationChairs_SkillsFrameworkTrackSpecializations_SFTrackSpecializationId",
                        column: x => x.SFTrackSpecializationId,
                        principalTable: "SkillsFrameworkTrackSpecializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationChairs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationChairs_SFTrackSpecializationId",
                table: "SpecializationChairs",
                column: "SFTrackSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationChairs_UserId",
                table: "SpecializationChairs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationChairs");
        }
    }
}
