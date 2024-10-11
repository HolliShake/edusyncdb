using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class RenamedDepartmentToCollge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingPeriods_Colleges_DepartmentId",
                table: "GradingPeriods");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "GradingPeriods",
                newName: "CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_GradingPeriods_DepartmentId",
                table: "GradingPeriods",
                newName: "IX_GradingPeriods_CollegeId");

            migrationBuilder.CreateTable(
                name: "TemplateGradeBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGradeBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateGradeBookItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TemplateGradeBookId = table.Column<int>(type: "int", nullable: false),
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGradeBookItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateGradeBookItems_GradingPeriods_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "GradingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateGradeBookItems_TemplateGradeBooks_TemplateGradeBookId",
                        column: x => x.TemplateGradeBookId,
                        principalTable: "TemplateGradeBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateGradeBookItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PassingScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TemplateGradeBookItemId = table.Column<int>(type: "int", nullable: false),
                    EqaAssessmentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGradeBookItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateGradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                        column: x => x.EqaAssessmentTypeId,
                        principalTable: "EducationalQualityAssuranceAssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateGradeBookItemDetails_TemplateGradeBookItems_TemplateGradeBookItemId",
                        column: x => x.TemplateGradeBookItemId,
                        principalTable: "TemplateGradeBookItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGradeBookItemDetails_EqaAssessmentTypeId",
                table: "TemplateGradeBookItemDetails",
                column: "EqaAssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGradeBookItemDetails_TemplateGradeBookItemId",
                table: "TemplateGradeBookItemDetails",
                column: "TemplateGradeBookItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGradeBookItems_GradingPeriodId",
                table: "TemplateGradeBookItems",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGradeBookItems_TemplateGradeBookId",
                table: "TemplateGradeBookItems",
                column: "TemplateGradeBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods");

            migrationBuilder.DropTable(
                name: "TemplateGradeBookItemDetails");

            migrationBuilder.DropTable(
                name: "TemplateGradeBookItems");

            migrationBuilder.DropTable(
                name: "TemplateGradeBooks");

            migrationBuilder.RenameColumn(
                name: "CollegeId",
                table: "GradingPeriods",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_GradingPeriods_CollegeId",
                table: "GradingPeriods",
                newName: "IX_GradingPeriods_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingPeriods_Colleges_DepartmentId",
                table: "GradingPeriods",
                column: "DepartmentId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
