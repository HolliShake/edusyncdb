using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationType",
                table: "AdmissionApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdmissionApplicantFamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    YearlyCompensation = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    YearLevel = table.Column<int>(type: "int", nullable: true),
                    AdmissionApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionApplicantFamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionApplicantFamilyDetails_AdmissionApplicants_AdmissionApplicantId",
                        column: x => x.AdmissionApplicantId,
                        principalTable: "AdmissionApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    CurriculumDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                        column: x => x.CurriculumDetailId,
                        principalTable: "CurriculumDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedSections_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionApplicantFamilyDetails_AdmissionApplicantId",
                table: "AdmissionApplicantFamilyDetails",
                column: "AdmissionApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedSections_CurriculumDetailId",
                table: "GeneratedSections",
                column: "CurriculumDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedSections_CycleId",
                table: "GeneratedSections",
                column: "CycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionApplicantFamilyDetails");

            migrationBuilder.DropTable(
                name: "GeneratedSections");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "AdmissionApplicants");
        }
    }
}
