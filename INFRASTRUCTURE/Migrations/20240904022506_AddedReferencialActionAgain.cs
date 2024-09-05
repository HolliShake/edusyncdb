using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferencialActionAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessGroups_AccessGroupId",
                table: "AccessLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_DuWhoTagId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_UnclearedUserId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_UserWhoClearedId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Users_CreditToUserId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Users_EvaluatedByUserId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplaineeUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_EncodedByUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccesses_Users_UserId",
                table: "UserAccesses");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessGroups_AccessGroupId",
                table: "AccessLists",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId",
                principalTable: "AccessLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins",
                column: "PostedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_DuWhoTagId",
                table: "ClearanceTags",
                column: "DuWhoTagId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_UnclearedUserId",
                table: "ClearanceTags",
                column: "UnclearedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_UserWhoClearedId",
                table: "ClearanceTags",
                column: "UserWhoClearedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings",
                column: "OtherSchoolId",
                principalTable: "OtherSchools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Users_CreditToUserId",
                table: "CourseCreditings",
                column: "CreditToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Users_EvaluatedByUserId",
                table: "CourseCreditings",
                column: "EvaluatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses",
                column: "ParentId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings",
                column: "EducationalQualityAssuranceLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades",
                column: "GradeInputId",
                principalTable: "GradeInputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs",
                column: "LogByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments",
                column: "CashierId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails",
                column: "EvaluationRatingId",
                principalTable: "EvaluationRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants",
                column: "GraduatingStudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters",
                column: "ParentId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses",
                column: "PetitionByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions",
                column: "ImposedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                table: "PortfolioIncidents",
                column: "ComplainantUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplaineeUserId",
                table: "PortfolioIncidents",
                column: "ComplaineeUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_EncodedByUserId",
                table: "PortfolioIncidents",
                column: "EncodedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances",
                column: "AnyUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications",
                column: "ApplicantUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations",
                column: "EvaluatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines",
                column: "ParentId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "SkillsFrameworkSkillsToCompetencyId",
                principalTable: "SkillsFrameworkSkillsToCompetencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SkillsFrameworkSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects",
                column: "ParentId",
                principalTable: "TableObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccesses_Users_UserId",
                table: "UserAccesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessGroups_AccessGroupId",
                table: "AccessLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_DuWhoTagId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_UnclearedUserId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_Users_UserWhoClearedId",
                table: "ClearanceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Users_CreditToUserId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Users_EvaluatedByUserId",
                table: "CourseCreditings");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplaineeUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_Users_EncodedByUserId",
                table: "PortfolioIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccesses_Users_UserId",
                table: "UserAccesses");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessGroups_AccessGroupId",
                table: "AccessLists",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId",
                principalTable: "AccessLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins",
                column: "PostedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_DuWhoTagId",
                table: "ClearanceTags",
                column: "DuWhoTagId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_UnclearedUserId",
                table: "ClearanceTags",
                column: "UnclearedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_UserWhoClearedId",
                table: "ClearanceTags",
                column: "UserWhoClearedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                table: "CourseCreditings",
                column: "OtherSchoolId",
                principalTable: "OtherSchools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Users_CreditToUserId",
                table: "CourseCreditings",
                column: "CreditToUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Users_EvaluatedByUserId",
                table: "CourseCreditings",
                column: "EvaluatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses",
                column: "ParentId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings",
                column: "EducationalQualityAssuranceLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades",
                column: "GradeInputId",
                principalTable: "GradeInputs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs",
                column: "LogByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments",
                column: "CashierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails",
                column: "EvaluationRatingId",
                principalTable: "EvaluationRatings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants",
                column: "GraduatingStudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters",
                column: "ParentId",
                principalTable: "Parameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses",
                column: "PetitionByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions",
                column: "ImposedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                table: "PortfolioIncidents",
                column: "ComplainantUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplaineeUserId",
                table: "PortfolioIncidents",
                column: "ComplaineeUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_EncodedByUserId",
                table: "PortfolioIncidents",
                column: "EncodedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances",
                column: "AnyUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications",
                column: "ApplicantUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations",
                column: "EvaluatorUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines",
                column: "ParentId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "SkillsFrameworkSkillsToCompetencyId",
                principalTable: "SkillsFrameworkSkillsToCompetencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SkillsFrameworkSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects",
                column: "ParentId",
                principalTable: "TableObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccesses_Users_UserId",
                table: "UserAccesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
