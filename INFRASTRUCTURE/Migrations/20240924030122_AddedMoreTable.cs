using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "AdmissionApplicants",
                newName: "BirthDate");

            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramChoiceId1",
                table: "AdmissionApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramChoiceId2",
                table: "AdmissionApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramChoiceId3",
                table: "AdmissionApplicants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChildOfSoloParent",
                table: "AdmissionApplicants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnsite",
                table: "AdmissionApplicants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoloParent",
                table: "AdmissionApplicants",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicProgramChoiceId1",
                table: "AdmissionApplicants");

            migrationBuilder.DropColumn(
                name: "AcademicProgramChoiceId2",
                table: "AdmissionApplicants");

            migrationBuilder.DropColumn(
                name: "AcademicProgramChoiceId3",
                table: "AdmissionApplicants");

            migrationBuilder.DropColumn(
                name: "IsChildOfSoloParent",
                table: "AdmissionApplicants");

            migrationBuilder.DropColumn(
                name: "IsOnsite",
                table: "AdmissionApplicants");

            migrationBuilder.DropColumn(
                name: "IsSoloParent",
                table: "AdmissionApplicants");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AdmissionApplicants",
                newName: "DateTime");
        }
    }
}
