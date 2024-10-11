using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class RefreshReferentialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_Cycles_CycleId",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_GradingPeriods_GradingPeriodId",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Colleges_CollegeId",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupActions_AccessGroups_AccessGroupId",
                table: "AccessGroupActions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplicantFamilyDetails_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplicantFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplications_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplications_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionEvaluationSchedules_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionEvaluationSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionProgramRequirements_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionProgramRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionProgramRequirements_Requirements_RequirementId",
                table: "AdmissionProgramRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionSchedules_AcademicPrograms_AcademicProgramId",
                table: "AdmissionSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionSchedules_Cycles_CycleId",
                table: "AdmissionSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionEvaluationSchedules_AdmissionEvaluationScheduleId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionProgramRequirements_AdmissionProgramRequirementId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Campuses_CampusId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_BulletinCategories_BulletinCategoryId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_BulletinScopes_AcademicPrograms_AcademicProgramId",
                table: "BulletinScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_BulletinScopes_Bulletins_BulletinId",
                table: "BulletinScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Agencies_AgencyId",
                table: "Campuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_ClearanceTypes_ClearanceTypeId",
                table: "ClearanceTags");

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
                name: "FK_Colleges_Campuses_CampusId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Courses_CourseId",
                table: "CourseCreditings");

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
                name: "FK_CourseFees_Courses_CourseId",
                table: "CourseFees");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFees_EnrollmentFees_FeeId",
                table: "CourseFees");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRequisites_Courses_CourseId",
                table: "CourseRequisites");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRequisites_Courses_RequisiteCourseId",
                table: "CourseRequisites");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_EducationalQualityAssuranceTypes_EducationalQualityAssuranceTypeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_Courses_CourseId",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicPrograms_AcademicProgramId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicTerms_AcademicTermId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_GradeInputs_MinGradeToBeCulledId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_ProgramTypes_ProgramTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetails_Courses_CourseId",
                table: "CurriculumDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetails_Curricula_CurriculumId",
                table: "CurriculumDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Cycles_Campuses_CampusId",
                table: "Cycles");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceCourseObjectives_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceCourseObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceEducationalGoals_EducationalQualityAssuranceTypes_EqaTypeId",
                table: "EducationalQualityAssuranceEducationalGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceCourseObjectives_EqaCourseObjectiveId",
                table: "EducationalQualityAssuranceLearningObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectives_EducationalQualityAssuranceEducationalGoals_EqaEducationalGoalId",
                table: "EducationalQualityAssuranceProgramObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Cycles_CycleId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_EnrollmentFees_EnrollmentFeeId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Enrollments_EnrollmentId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Vouchers_VoucherId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentFees_FundSources_FundSourceId",
                table: "EnrollmentFees");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentFees_TableObjects_ObjectId",
                table: "EnrollmentFees");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_Enrollments_EnrollmentId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradingPeriods_GradingPeriodId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Enrollments_EnrollmentId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_EnrollmentBillings_EnrollmentBillingId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_EnrollmentRoles_EnrollmentRoleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Schedules_ScheduleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_AcademicPrograms_AcademicProgramId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Cycles_CycleId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_EnrollmentRoles_EnrollmentRoleId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Instruments_InstrumentId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_LikertQuestions_LikertQuestionId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatings_Enrollments_EnrollmentId",
                table: "EvaluationRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatings_EvaluationPeriods_EvaluationPeriodId",
                table: "EvaluationRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                table: "GeneratedSections");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSections_Cycles_CycleId",
                table: "GeneratedSections");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "GradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemDetails_GradeBookItems_GradeBookItemId",
                table: "GradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItems_GradeBooks_GradeBookId",
                table: "GradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItems_GradingPeriods_GradingPeriodId",
                table: "GradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EqaLearningObjectiveId",
                table: "GradeBookItemToEqaLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookItemToEqaLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBooks_Schedules_ScheduleId",
                table: "GradeBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookScores_Enrollments_EnrollmentId",
                table: "GradeBookScores");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_AcademicPrograms_AcademicProgramId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_GraduationCampuses_GraduationCampusId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationCampuses_Campuses_CampusId",
                table: "GraduationCampuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LikertQuestions_Parameters_ParameterId",
                table: "LikertQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterCategories_Instruments_InstrumentId",
                table: "ParameterCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ParameterSubCategories_ParameterSubCategoryId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterSubCategories_ParameterCategories_ParameterCategoryId",
                table: "ParameterSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_AcademicPrograms_AcademicProgramId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Courses_CourseId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Cycles_CycleId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_PortfolioIncidents_PortfolioIncidentId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioProviders_PortfolioProviderId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioScopes_PortfolioScopeId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioTypes_PortfolioTypeId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkSkills_SfSkillsId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_PortfolioIncidentTypes_PortfolioIncidentTypeId",
                table: "PortfolioIncidents");

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
                name: "FK_PortfolioProviders_SectorDisciplines_SectorDisciplineId",
                table: "PortfolioProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_PortfolioSessions_PortfolioSessionId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessions_PortfolioSessionTypes_PortfolioSessionTypeId",
                table: "PortfolioSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Schedules_ScheduleId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleMerges_Schedules_ScheduleId",
                table: "ScheduleMerges");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Cycles_CycleId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_EnrollmentRoles_EnrollmentRoleId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Schedules_ScheduleId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_ScholarshipCycleLimits_ScholarshipCycleLimitId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipCycleLimits_Cycles_CycleId",
                table: "ScholarshipCycleLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipCycleLimits_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipCycleLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipApplications_ScholarshipApplicationId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipRequirements_ScholarshipRequirementId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipRequirements_Requirements_RequirementId",
                table: "ScholarshipRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipRequirements_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkCompetencyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SkillsFrameworkCompetencyTypes_SfCompetencyTypeId",
                table: "SkillsFrameworkCompetencyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_Courses_CourseId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleJobRoles_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "SkillsFrameworkJobRoleJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleToCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkKeyTasks_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkKeyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkPerformanceExpectations_SfPerformanceExpectationId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkProficiencyLevels_SkillsFrameworkGroupLevels_SfGroupLevelId",
                table: "SkillsFrameworkProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkills_SkillsFrameworkCompetencyCategories_SfCompetencyCategoryId",
                table: "SkillsFrameworkSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkCompetencies_SfCompetencyId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkills_SfSkillsId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkTrackSpecializations_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkTrackSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_AccountGroups_AccountGroupId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "TemplateGradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItemDetails_TemplateGradeBookItems_TemplateGradeBookItemId",
                table: "TemplateGradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItems_GradingPeriods_GradingPeriodId",
                table: "TemplateGradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItems_TemplateGradeBooks_TemplateGradeBookId",
                table: "TemplateGradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessGroupDetails_AccessGroupActions_AccessGroupActionId",
                table: "UserAccessGroupDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessGroupDetails_Users_UserId",
                table: "UserAccessGroupDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampusDetails_Campuses_CampusId",
                table: "UserCampusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampusDetails_Users_UserId",
                table: "UserCampusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherApplied_EnrollmentBillings_EnrollmentBillingId",
                table: "VoucherApplied");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherApplied_Vouchers_VoucherId",
                table: "VoucherApplied");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_Cycles_CycleId",
                table: "AcademicCalendars",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_GradingPeriods_GradingPeriodId",
                table: "AcademicCalendars",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Colleges_CollegeId",
                table: "AcademicPrograms",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupActions_AccessGroups_AccessGroupId",
                table: "AccessGroupActions",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplicantFamilyDetails_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplicantFamilyDetails",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplications_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplications",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplications_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionApplications",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionEvaluationSchedules_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionEvaluationSchedules",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionProgramRequirements_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionProgramRequirements",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionProgramRequirements_Requirements_RequirementId",
                table: "AdmissionProgramRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionSchedules_AcademicPrograms_AcademicProgramId",
                table: "AdmissionSchedules",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionSchedules_Cycles_CycleId",
                table: "AdmissionSchedules",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionScores",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionEvaluationSchedules_AdmissionEvaluationScheduleId",
                table: "AdmissionScores",
                column: "AdmissionEvaluationScheduleId",
                principalTable: "AdmissionEvaluationSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionProgramRequirements_AdmissionProgramRequirementId",
                table: "AdmissionScores",
                column: "AdmissionProgramRequirementId",
                principalTable: "AdmissionProgramRequirements",
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
                name: "FK_Buildings_Campuses_CampusId",
                table: "Buildings",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_BulletinCategories_BulletinCategoryId",
                table: "Bulletins",
                column: "BulletinCategoryId",
                principalTable: "BulletinCategories",
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
                name: "FK_BulletinScopes_AcademicPrograms_AcademicProgramId",
                table: "BulletinScopes",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BulletinScopes_Bulletins_BulletinId",
                table: "BulletinScopes",
                column: "BulletinId",
                principalTable: "Bulletins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Agencies_AgencyId",
                table: "Campuses",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_ClearanceTypes_ClearanceTypeId",
                table: "ClearanceTags",
                column: "ClearanceTypeId",
                principalTable: "ClearanceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_Users_DuWhoTagId",
                table: "ClearanceTags",
                column: "DuWhoTagId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Colleges_Campuses_CampusId",
                table: "Colleges",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Courses_CourseId",
                table: "CourseCreditings",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_CourseFees_Courses_CourseId",
                table: "CourseFees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFees_EnrollmentFees_FeeId",
                table: "CourseFees",
                column: "FeeId",
                principalTable: "EnrollmentFees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRequisites_Courses_CourseId",
                table: "CourseRequisites",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRequisites_Courses_RequisiteCourseId",
                table: "CourseRequisites",
                column: "RequisiteCourseId",
                principalTable: "Courses",
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
                name: "FK_Courses_EducationalQualityAssuranceTypes_EducationalQualityAssuranceTypeId",
                table: "Courses",
                column: "EducationalQualityAssuranceTypeId",
                principalTable: "EducationalQualityAssuranceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "Courses",
                column: "SfTrackSpecializationId",
                principalTable: "SkillsFrameworkTrackSpecializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_Courses_CourseId",
                table: "CourseToLearningObjectiveMappings",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings",
                column: "EducationalQualityAssuranceLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicPrograms_AcademicProgramId",
                table: "Curricula",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicTerms_AcademicTermId",
                table: "Curricula",
                column: "AcademicTermId",
                principalTable: "AcademicTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_GradeInputs_MinGradeToBeCulledId",
                table: "Curricula",
                column: "MinGradeToBeCulledId",
                principalTable: "GradeInputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_ProgramTypes_ProgramTypeId",
                table: "Curricula",
                column: "ProgramTypeId",
                principalTable: "ProgramTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetails_Courses_CourseId",
                table: "CurriculumDetails",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetails_Curricula_CurriculumId",
                table: "CurriculumDetails",
                column: "CurriculumId",
                principalTable: "Curricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cycles_Campuses_CampusId",
                table: "Cycles",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceCourseObjectives_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceCourseObjectives",
                column: "EqaProgramObjectiveId",
                principalTable: "EducationalQualityAssuranceProgramObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceEducationalGoals_EducationalQualityAssuranceTypes_EqaTypeId",
                table: "EducationalQualityAssuranceEducationalGoals",
                column: "EqaTypeId",
                principalTable: "EducationalQualityAssuranceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceCourseObjectives_EqaCourseObjectiveId",
                table: "EducationalQualityAssuranceLearningObjectives",
                column: "EqaCourseObjectiveId",
                principalTable: "EducationalQualityAssuranceCourseObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectives_EducationalQualityAssuranceEducationalGoals_EqaEducationalGoalId",
                table: "EducationalQualityAssuranceProgramObjectives",
                column: "EqaEducationalGoalId",
                principalTable: "EducationalQualityAssuranceEducationalGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "EqaProgramObjectiveId",
                principalTable: "EducationalQualityAssuranceProgramObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Cycles_CycleId",
                table: "EnrollmentBillings",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_EnrollmentFees_EnrollmentFeeId",
                table: "EnrollmentBillings",
                column: "EnrollmentFeeId",
                principalTable: "EnrollmentFees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Enrollments_EnrollmentId",
                table: "EnrollmentBillings",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Vouchers_VoucherId",
                table: "EnrollmentBillings",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentFees_FundSources_FundSourceId",
                table: "EnrollmentFees",
                column: "FundSourceId",
                principalTable: "FundSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentFees_TableObjects_ObjectId",
                table: "EnrollmentFees",
                column: "ObjectId",
                principalTable: "TableObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_Enrollments_EnrollmentId",
                table: "EnrollmentGrades",
                column: "EnrollmentId",
                principalTable: "Enrollments",
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
                name: "FK_EnrollmentGrades_GradingPeriods_GradingPeriodId",
                table: "EnrollmentGrades",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades",
                column: "EncodedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentLogs_Enrollments_EnrollmentId",
                table: "EnrollmentLogs",
                column: "EnrollmentId",
                principalTable: "Enrollments",
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
                name: "FK_EnrollmentPayments_EnrollmentBillings_EnrollmentBillingId",
                table: "EnrollmentPayments",
                column: "EnrollmentBillingId",
                principalTable: "EnrollmentBillings",
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
                name: "FK_Enrollments_EnrollmentRoles_EnrollmentRoleId",
                table: "Enrollments",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Schedules_ScheduleId",
                table: "Enrollments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_AcademicPrograms_AcademicProgramId",
                table: "EvaluationPeriods",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Cycles_CycleId",
                table: "EvaluationPeriods",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_EnrollmentRoles_EnrollmentRoleId",
                table: "EvaluationPeriods",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Instruments_InstrumentId",
                table: "EvaluationPeriods",
                column: "InstrumentId",
                principalTable: "Instruments",
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
                name: "FK_EvaluationRatingDetails_LikertQuestions_LikertQuestionId",
                table: "EvaluationRatingDetails",
                column: "LikertQuestionId",
                principalTable: "LikertQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatings_Enrollments_EnrollmentId",
                table: "EvaluationRatings",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatings_EvaluationPeriods_EvaluationPeriodId",
                table: "EvaluationRatings",
                column: "EvaluationPeriodId",
                principalTable: "EvaluationPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                table: "GeneratedSections",
                column: "CurriculumDetailId",
                principalTable: "CurriculumDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSections_Cycles_CycleId",
                table: "GeneratedSections",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "GradeBookItemDetails",
                column: "EqaAssessmentTypeId",
                principalTable: "EducationalQualityAssuranceAssessmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemDetails_GradeBookItems_GradeBookItemId",
                table: "GradeBookItemDetails",
                column: "GradeBookItemId",
                principalTable: "GradeBookItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItems_GradeBooks_GradeBookId",
                table: "GradeBookItems",
                column: "GradeBookId",
                principalTable: "GradeBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItems_GradingPeriods_GradingPeriodId",
                table: "GradeBookItems",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EqaLearningObjectiveId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "EqaLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "GradeBookItemDetailId",
                principalTable: "GradeBookItemDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBooks_Schedules_ScheduleId",
                table: "GradeBooks",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookScores_Enrollments_EnrollmentId",
                table: "GradeBookScores",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_AcademicPrograms_AcademicProgramId",
                table: "GraduationApplicants",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_GraduationCampuses_GraduationCampusId",
                table: "GraduationApplicants",
                column: "GraduationCampusId",
                principalTable: "GraduationCampuses",
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
                name: "FK_GraduationCampuses_Campuses_CampusId",
                table: "GraduationCampuses",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LikertQuestions_Parameters_ParameterId",
                table: "LikertQuestions",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterCategories_Instruments_InstrumentId",
                table: "ParameterCategories",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ParameterSubCategories_ParameterSubCategoryId",
                table: "Parameters",
                column: "ParameterSubCategoryId",
                principalTable: "ParameterSubCategories",
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
                name: "FK_ParameterSubCategories_ParameterCategories_ParameterCategoryId",
                table: "ParameterSubCategories",
                column: "ParameterCategoryId",
                principalTable: "ParameterCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_AcademicPrograms_AcademicProgramId",
                table: "PetitionCourses",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Courses_CourseId",
                table: "PetitionCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Cycles_CycleId",
                table: "PetitionCourses",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses",
                column: "PetitionByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDisciplinaryActions_PortfolioIncidents_PortfolioIncidentId",
                table: "PortfolioDisciplinaryActions",
                column: "PortfolioIncidentId",
                principalTable: "PortfolioIncidents",
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
                name: "FK_PortfolioEntries_PortfolioProviders_PortfolioProviderId",
                table: "PortfolioEntries",
                column: "PortfolioProviderId",
                principalTable: "PortfolioProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_PortfolioScopes_PortfolioScopeId",
                table: "PortfolioEntries",
                column: "PortfolioScopeId",
                principalTable: "PortfolioScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_PortfolioTypes_PortfolioTypeId",
                table: "PortfolioEntries",
                column: "PortfolioTypeId",
                principalTable: "PortfolioTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "PortfolioEntries",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkSkills_SfSkillsId",
                table: "PortfolioEntries",
                column: "SfSkillsId",
                principalTable: "SkillsFrameworkSkills",
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
                name: "FK_PortfolioIncidents_PortfolioIncidentTypes_PortfolioIncidentTypeId",
                table: "PortfolioIncidents",
                column: "PortfolioIncidentTypeId",
                principalTable: "PortfolioIncidentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                table: "PortfolioIncidents",
                column: "ComplainantUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_PortfolioProviders_SectorDisciplines_SectorDisciplineId",
                table: "PortfolioProviders",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_PortfolioSessions_PortfolioSessionId",
                table: "PortfolioSessionInvolved",
                column: "PortfolioSessionId",
                principalTable: "PortfolioSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessions_PortfolioSessionTypes_PortfolioSessionTypeId",
                table: "PortfolioSessions",
                column: "PortfolioSessionTypeId",
                principalTable: "PortfolioSessionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAttendances_Schedules_ScheduleId",
                table: "ScheduleAttendances",
                column: "ScheduleId",
                principalTable: "Schedules",
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
                name: "FK_ScheduleMerges_Schedules_ScheduleId",
                table: "ScheduleMerges",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Cycles_CycleId",
                table: "Schedules",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_EnrollmentRoles_EnrollmentRoleId",
                table: "ScheduleTeachers",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_Schedules_ScheduleId",
                table: "ScheduleTeachers",
                column: "ScheduleId",
                principalTable: "Schedules",
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
                name: "FK_ScholarshipApplications_ScholarshipCycleLimits_ScholarshipCycleLimitId",
                table: "ScholarshipApplications",
                column: "ScholarshipCycleLimitId",
                principalTable: "ScholarshipCycleLimits",
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
                name: "FK_ScholarshipCycleLimits_Cycles_CycleId",
                table: "ScholarshipCycleLimits",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipCycleLimits_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipCycleLimits",
                column: "ScholarshipListId",
                principalTable: "ScholarshipLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipApplications_ScholarshipApplicationId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipApplicationId",
                principalTable: "ScholarshipApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipRequirements_ScholarshipRequirementId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipRequirementId",
                principalTable: "ScholarshipRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations",
                column: "EvaluatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipRequirements_Requirements_RequirementId",
                table: "ScholarshipRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipRequirements_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipRequirements",
                column: "ScholarshipListId",
                principalTable: "ScholarshipLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines",
                column: "ParentId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SkillsFrameworkCompetencyTypes_SfCompetencyTypeId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SfCompetencyTypeId",
                principalTable: "SkillsFrameworkCompetencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_Courses_CourseId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "SkillsFrameworkSkillsToCompetencyId",
                principalTable: "SkillsFrameworkSkillsToCompetencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleJobRoles_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "SkillsFrameworkJobRoleJobRoles",
                column: "SfTrackSpecializationId",
                principalTable: "SkillsFrameworkTrackSpecializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkCriticalWorkFunctions",
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
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleToCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfJobRoleToCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
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
                name: "FK_SkillsFrameworkKeyTasks_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkKeyTasks",
                column: "SfCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkCriticalWorkFunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkPerformanceExpectations_SfPerformanceExpectationId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfPerformanceExpectationId",
                principalTable: "SkillsFrameworkPerformanceExpectations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkProficiencyLevels_SkillsFrameworkGroupLevels_SfGroupLevelId",
                table: "SkillsFrameworkProficiencyLevels",
                column: "SfGroupLevelId",
                principalTable: "SkillsFrameworkGroupLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkills_SkillsFrameworkCompetencyCategories_SfCompetencyCategoryId",
                table: "SkillsFrameworkSkills",
                column: "SfCompetencyCategoryId",
                principalTable: "SkillsFrameworkCompetencyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkCompetencies_SfCompetencyId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfCompetencyId",
                principalTable: "SkillsFrameworkCompetencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkills_SfSkillsId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkTrackSpecializations_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkTrackSpecializations",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableObjects_AccountGroups_AccountGroupId",
                table: "TableObjects",
                column: "AccountGroupId",
                principalTable: "AccountGroups",
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
                name: "FK_TemplateGradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "TemplateGradeBookItemDetails",
                column: "EqaAssessmentTypeId",
                principalTable: "EducationalQualityAssuranceAssessmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItemDetails_TemplateGradeBookItems_TemplateGradeBookItemId",
                table: "TemplateGradeBookItemDetails",
                column: "TemplateGradeBookItemId",
                principalTable: "TemplateGradeBookItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItems_GradingPeriods_GradingPeriodId",
                table: "TemplateGradeBookItems",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItems_TemplateGradeBooks_TemplateGradeBookId",
                table: "TemplateGradeBookItems",
                column: "TemplateGradeBookId",
                principalTable: "TemplateGradeBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessGroupDetails_AccessGroupActions_AccessGroupActionId",
                table: "UserAccessGroupDetails",
                column: "AccessGroupActionId",
                principalTable: "AccessGroupActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessGroupDetails_Users_UserId",
                table: "UserAccessGroupDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampusDetails_Campuses_CampusId",
                table: "UserCampusDetails",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampusDetails_Users_UserId",
                table: "UserCampusDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherApplied_EnrollmentBillings_EnrollmentBillingId",
                table: "VoucherApplied",
                column: "EnrollmentBillingId",
                principalTable: "EnrollmentBillings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherApplied_Vouchers_VoucherId",
                table: "VoucherApplied",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_Cycles_CycleId",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_GradingPeriods_GradingPeriodId",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Colleges_CollegeId",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupActions_AccessGroups_AccessGroupId",
                table: "AccessGroupActions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplicantFamilyDetails_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplicantFamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplications_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionApplications_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionEvaluationSchedules_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionEvaluationSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionProgramRequirements_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionProgramRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionProgramRequirements_Requirements_RequirementId",
                table: "AdmissionProgramRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionSchedules_AcademicPrograms_AcademicProgramId",
                table: "AdmissionSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionSchedules_Cycles_CycleId",
                table: "AdmissionSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionEvaluationSchedules_AdmissionEvaluationScheduleId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_AdmissionProgramRequirements_AdmissionProgramRequirementId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Campuses_CampusId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_BulletinCategories_BulletinCategoryId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins");

            migrationBuilder.DropForeignKey(
                name: "FK_BulletinScopes_AcademicPrograms_AcademicProgramId",
                table: "BulletinScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_BulletinScopes_Bulletins_BulletinId",
                table: "BulletinScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Agencies_AgencyId",
                table: "Campuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClearanceTags_ClearanceTypes_ClearanceTypeId",
                table: "ClearanceTags");

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
                name: "FK_Colleges_Campuses_CampusId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCreditings_Courses_CourseId",
                table: "CourseCreditings");

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
                name: "FK_CourseFees_Courses_CourseId",
                table: "CourseFees");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFees_EnrollmentFees_FeeId",
                table: "CourseFees");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRequisites_Courses_CourseId",
                table: "CourseRequisites");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRequisites_Courses_RequisiteCourseId",
                table: "CourseRequisites");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_EducationalQualityAssuranceTypes_EducationalQualityAssuranceTypeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_Courses_CourseId",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicPrograms_AcademicProgramId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_AcademicTerms_AcademicTermId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_GradeInputs_MinGradeToBeCulledId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Curricula_ProgramTypes_ProgramTypeId",
                table: "Curricula");

            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetails_Courses_CourseId",
                table: "CurriculumDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumDetails_Curricula_CurriculumId",
                table: "CurriculumDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Cycles_Campuses_CampusId",
                table: "Cycles");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceCourseObjectives_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceCourseObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceEducationalGoals_EducationalQualityAssuranceTypes_EqaTypeId",
                table: "EducationalQualityAssuranceEducationalGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceCourseObjectives_EqaCourseObjectiveId",
                table: "EducationalQualityAssuranceLearningObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectives_EducationalQualityAssuranceEducationalGoals_EqaEducationalGoalId",
                table: "EducationalQualityAssuranceProgramObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Cycles_CycleId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_EnrollmentFees_EnrollmentFeeId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Enrollments_EnrollmentId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentBillings_Vouchers_VoucherId",
                table: "EnrollmentBillings");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentFees_FundSources_FundSourceId",
                table: "EnrollmentFees");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentFees_TableObjects_ObjectId",
                table: "EnrollmentFees");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_Enrollments_EnrollmentId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_GradingPeriods_GradingPeriodId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Enrollments_EnrollmentId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_EnrollmentBillings_EnrollmentBillingId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_EnrollmentRoles_EnrollmentRoleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Schedules_ScheduleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_AcademicPrograms_AcademicProgramId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Cycles_CycleId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_EnrollmentRoles_EnrollmentRoleId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Instruments_InstrumentId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                table: "EvaluationPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatingDetails_LikertQuestions_LikertQuestionId",
                table: "EvaluationRatingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatings_Enrollments_EnrollmentId",
                table: "EvaluationRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationRatings_EvaluationPeriods_EvaluationPeriodId",
                table: "EvaluationRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                table: "GeneratedSections");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSections_Cycles_CycleId",
                table: "GeneratedSections");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "GradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemDetails_GradeBookItems_GradeBookItemId",
                table: "GradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItems_GradeBooks_GradeBookId",
                table: "GradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItems_GradingPeriods_GradingPeriodId",
                table: "GradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EqaLearningObjectiveId",
                table: "GradeBookItemToEqaLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookItemToEqaLearningObjectiveMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBooks_Schedules_ScheduleId",
                table: "GradeBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_GradeBookScores_Enrollments_EnrollmentId",
                table: "GradeBookScores");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_AcademicPrograms_AcademicProgramId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_GraduationCampuses_GraduationCampusId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduationCampuses_Campuses_CampusId",
                table: "GraduationCampuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LikertQuestions_Parameters_ParameterId",
                table: "LikertQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterCategories_Instruments_InstrumentId",
                table: "ParameterCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ParameterSubCategories_ParameterSubCategoryId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterSubCategories_ParameterCategories_ParameterCategoryId",
                table: "ParameterSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_AcademicPrograms_AcademicProgramId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Courses_CourseId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Cycles_CycleId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_PortfolioIncidents_PortfolioIncidentId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioProviders_PortfolioProviderId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioScopes_PortfolioScopeId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_PortfolioTypes_PortfolioTypeId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkSkills_SfSkillsId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioIncidents_PortfolioIncidentTypes_PortfolioIncidentTypeId",
                table: "PortfolioIncidents");

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
                name: "FK_PortfolioProviders_SectorDisciplines_SectorDisciplineId",
                table: "PortfolioProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_PortfolioSessions_PortfolioSessionId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSessions_PortfolioSessionTypes_PortfolioSessionTypeId",
                table: "PortfolioSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Schedules_ScheduleId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleMerges_Schedules_ScheduleId",
                table: "ScheduleMerges");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Cycles_CycleId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_EnrollmentRoles_EnrollmentRoleId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Schedules_ScheduleId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_ScholarshipCycleLimits_ScholarshipCycleLimitId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipCycleLimits_Cycles_CycleId",
                table: "ScholarshipCycleLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipCycleLimits_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipCycleLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipApplications_ScholarshipApplicationId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipRequirements_ScholarshipRequirementId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipRequirements_Requirements_RequirementId",
                table: "ScholarshipRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipRequirements_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkCompetencyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SkillsFrameworkCompetencyTypes_SfCompetencyTypeId",
                table: "SkillsFrameworkCompetencyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_Courses_CourseId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleJobRoles_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "SkillsFrameworkJobRoleJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleToCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkKeyTasks_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkKeyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkPerformanceExpectations_SfPerformanceExpectationId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkProficiencyLevels_SkillsFrameworkGroupLevels_SfGroupLevelId",
                table: "SkillsFrameworkProficiencyLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkills_SkillsFrameworkCompetencyCategories_SfCompetencyCategoryId",
                table: "SkillsFrameworkSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkCompetencies_SfCompetencyId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkills_SfSkillsId",
                table: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillsFrameworkTrackSpecializations_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkTrackSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_AccountGroups_AccountGroupId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "TemplateGradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItemDetails_TemplateGradeBookItems_TemplateGradeBookItemId",
                table: "TemplateGradeBookItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItems_GradingPeriods_GradingPeriodId",
                table: "TemplateGradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateGradeBookItems_TemplateGradeBooks_TemplateGradeBookId",
                table: "TemplateGradeBookItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessGroupDetails_AccessGroupActions_AccessGroupActionId",
                table: "UserAccessGroupDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessGroupDetails_Users_UserId",
                table: "UserAccessGroupDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampusDetails_Campuses_CampusId",
                table: "UserCampusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampusDetails_Users_UserId",
                table: "UserCampusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherApplied_EnrollmentBillings_EnrollmentBillingId",
                table: "VoucherApplied");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherApplied_Vouchers_VoucherId",
                table: "VoucherApplied");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_Cycles_CycleId",
                table: "AcademicCalendars",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_GradingPeriods_GradingPeriodId",
                table: "AcademicCalendars",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Colleges_CollegeId",
                table: "AcademicPrograms",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupActions_AccessGroups_AccessGroupId",
                table: "AccessGroupActions",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplicantFamilyDetails_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplicantFamilyDetails",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplications_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionApplications",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionApplications_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionApplications",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionEvaluationSchedules_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionEvaluationSchedules",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionProgramRequirements_AdmissionSchedules_AdmissionScheduleId",
                table: "AdmissionProgramRequirements",
                column: "AdmissionScheduleId",
                principalTable: "AdmissionSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionProgramRequirements_Requirements_RequirementId",
                table: "AdmissionProgramRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionSchedules_AcademicPrograms_AcademicProgramId",
                table: "AdmissionSchedules",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionSchedules_Cycles_CycleId",
                table: "AdmissionSchedules",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionApplicants_AdmissionApplicantId",
                table: "AdmissionScores",
                column: "AdmissionApplicantId",
                principalTable: "AdmissionApplicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionEvaluationSchedules_AdmissionEvaluationScheduleId",
                table: "AdmissionScores",
                column: "AdmissionEvaluationScheduleId",
                principalTable: "AdmissionEvaluationSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_AdmissionProgramRequirements_AdmissionProgramRequirementId",
                table: "AdmissionScores",
                column: "AdmissionProgramRequirementId",
                principalTable: "AdmissionProgramRequirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionScores_Users_EvaluatorId",
                table: "AdmissionScores",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Campuses_CampusId",
                table: "Buildings",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_BulletinCategories_BulletinCategoryId",
                table: "Bulletins",
                column: "BulletinCategoryId",
                principalTable: "BulletinCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_Users_PostedByUserId",
                table: "Bulletins",
                column: "PostedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BulletinScopes_AcademicPrograms_AcademicProgramId",
                table: "BulletinScopes",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BulletinScopes_Bulletins_BulletinId",
                table: "BulletinScopes",
                column: "BulletinId",
                principalTable: "Bulletins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Agencies_AgencyId",
                table: "Campuses",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClearanceTags_ClearanceTypes_ClearanceTypeId",
                table: "ClearanceTags",
                column: "ClearanceTypeId",
                principalTable: "ClearanceTypes",
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
                name: "FK_Colleges_Campuses_CampusId",
                table: "Colleges",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCreditings_Courses_CourseId",
                table: "CourseCreditings",
                column: "CourseId",
                principalTable: "Courses",
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
                name: "FK_CourseFees_Courses_CourseId",
                table: "CourseFees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFees_EnrollmentFees_FeeId",
                table: "CourseFees",
                column: "FeeId",
                principalTable: "EnrollmentFees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRequisites_Courses_CourseId",
                table: "CourseRequisites",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRequisites_Courses_RequisiteCourseId",
                table: "CourseRequisites",
                column: "RequisiteCourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_ParentId",
                table: "Courses",
                column: "ParentId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_EducationalQualityAssuranceTypes_EducationalQualityAssuranceTypeId",
                table: "Courses",
                column: "EducationalQualityAssuranceTypeId",
                principalTable: "EducationalQualityAssuranceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "Courses",
                column: "SfTrackSpecializationId",
                principalTable: "SkillsFrameworkTrackSpecializations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_Courses_CourseId",
                table: "CourseToLearningObjectiveMappings",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                table: "CourseToLearningObjectiveMappings",
                column: "EducationalQualityAssuranceLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicPrograms_AcademicProgramId",
                table: "Curricula",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_AcademicTerms_AcademicTermId",
                table: "Curricula",
                column: "AcademicTermId",
                principalTable: "AcademicTerms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_GradeInputs_MinGradeToBeCulledId",
                table: "Curricula",
                column: "MinGradeToBeCulledId",
                principalTable: "GradeInputs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curricula_ProgramTypes_ProgramTypeId",
                table: "Curricula",
                column: "ProgramTypeId",
                principalTable: "ProgramTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetails_Courses_CourseId",
                table: "CurriculumDetails",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumDetails_Curricula_CurriculumId",
                table: "CurriculumDetails",
                column: "CurriculumId",
                principalTable: "Curricula",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cycles_Campuses_CampusId",
                table: "Cycles",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceCourseObjectives_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceCourseObjectives",
                column: "EqaProgramObjectiveId",
                principalTable: "EducationalQualityAssuranceProgramObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceEducationalGoals_EducationalQualityAssuranceTypes_EqaTypeId",
                table: "EducationalQualityAssuranceEducationalGoals",
                column: "EqaTypeId",
                principalTable: "EducationalQualityAssuranceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceCourseObjectives_EqaCourseObjectiveId",
                table: "EducationalQualityAssuranceLearningObjectives",
                column: "EqaCourseObjectiveId",
                principalTable: "EducationalQualityAssuranceCourseObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectives_EducationalQualityAssuranceEducationalGoals_EqaEducationalGoalId",
                table: "EducationalQualityAssuranceProgramObjectives",
                column: "EqaEducationalGoalId",
                principalTable: "EducationalQualityAssuranceEducationalGoals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "EqaProgramObjectiveId",
                principalTable: "EducationalQualityAssuranceProgramObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Cycles_CycleId",
                table: "EnrollmentBillings",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_EnrollmentFees_EnrollmentFeeId",
                table: "EnrollmentBillings",
                column: "EnrollmentFeeId",
                principalTable: "EnrollmentFees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Enrollments_EnrollmentId",
                table: "EnrollmentBillings",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentBillings_Vouchers_VoucherId",
                table: "EnrollmentBillings",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentFees_FundSources_FundSourceId",
                table: "EnrollmentFees",
                column: "FundSourceId",
                principalTable: "FundSources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentFees_TableObjects_ObjectId",
                table: "EnrollmentFees",
                column: "ObjectId",
                principalTable: "TableObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_Enrollments_EnrollmentId",
                table: "EnrollmentGrades",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                table: "EnrollmentGrades",
                column: "GradeInputId",
                principalTable: "GradeInputs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_GradingPeriods_GradingPeriodId",
                table: "EnrollmentGrades",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentGrades_Users_EncodedByUserId",
                table: "EnrollmentGrades",
                column: "EncodedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentLogs_Enrollments_EnrollmentId",
                table: "EnrollmentLogs",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentLogs_Users_LogByUserId",
                table: "EnrollmentLogs",
                column: "LogByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentPayments_EnrollmentBillings_EnrollmentBillingId",
                table: "EnrollmentPayments",
                column: "EnrollmentBillingId",
                principalTable: "EnrollmentBillings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentPayments_Users_CashierId",
                table: "EnrollmentPayments",
                column: "CashierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_EnrollmentRoles_EnrollmentRoleId",
                table: "Enrollments",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Schedules_ScheduleId",
                table: "Enrollments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_StudentUserId",
                table: "Enrollments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_AcademicPrograms_AcademicProgramId",
                table: "EvaluationPeriods",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Cycles_CycleId",
                table: "EvaluationPeriods",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_EnrollmentRoles_EnrollmentRoleId",
                table: "EvaluationPeriods",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationPeriods_Instruments_InstrumentId",
                table: "EvaluationPeriods",
                column: "InstrumentId",
                principalTable: "Instruments",
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
                name: "FK_EvaluationRatingDetails_LikertQuestions_LikertQuestionId",
                table: "EvaluationRatingDetails",
                column: "LikertQuestionId",
                principalTable: "LikertQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatings_Enrollments_EnrollmentId",
                table: "EvaluationRatings",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationRatings_EvaluationPeriods_EvaluationPeriodId",
                table: "EvaluationRatings",
                column: "EvaluationPeriodId",
                principalTable: "EvaluationPeriods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSections_CurriculumDetails_CurriculumDetailId",
                table: "GeneratedSections",
                column: "CurriculumDetailId",
                principalTable: "CurriculumDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSections_Cycles_CycleId",
                table: "GeneratedSections",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "GradeBookItemDetails",
                column: "EqaAssessmentTypeId",
                principalTable: "EducationalQualityAssuranceAssessmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemDetails_GradeBookItems_GradeBookItemId",
                table: "GradeBookItemDetails",
                column: "GradeBookItemId",
                principalTable: "GradeBookItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItems_GradeBooks_GradeBookId",
                table: "GradeBookItems",
                column: "GradeBookId",
                principalTable: "GradeBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItems_GradingPeriods_GradingPeriodId",
                table: "GradeBookItems",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EqaLearningObjectiveId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "EqaLearningObjectiveId",
                principalTable: "EducationalQualityAssuranceLearningObjectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetails_GradeBookItemDetailId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "GradeBookItemDetailId",
                principalTable: "GradeBookItemDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBooks_Schedules_ScheduleId",
                table: "GradeBooks",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeBookScores_Enrollments_EnrollmentId",
                table: "GradeBookScores",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingPeriods_Colleges_CollegeId",
                table: "GradingPeriods",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_AcademicPrograms_AcademicProgramId",
                table: "GraduationApplicants",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_GraduationCampuses_GraduationCampusId",
                table: "GraduationApplicants",
                column: "GraduationCampusId",
                principalTable: "GraduationCampuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                table: "GraduationApplicants",
                column: "GraduatingStudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduationCampuses_Campuses_CampusId",
                table: "GraduationCampuses",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikertQuestions_Parameters_ParameterId",
                table: "LikertQuestions",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterCategories_Instruments_InstrumentId",
                table: "ParameterCategories",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ParameterSubCategories_ParameterSubCategoryId",
                table: "Parameters",
                column: "ParameterSubCategoryId",
                principalTable: "ParameterSubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Parameters_ParentId",
                table: "Parameters",
                column: "ParentId",
                principalTable: "Parameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterSubCategories_ParameterCategories_ParameterCategoryId",
                table: "ParameterSubCategories",
                column: "ParameterCategoryId",
                principalTable: "ParameterCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_AcademicPrograms_AcademicProgramId",
                table: "PetitionCourses",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Courses_CourseId",
                table: "PetitionCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Cycles_CycleId",
                table: "PetitionCourses",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionCourses_Users_PetitionByUserId",
                table: "PetitionCourses",
                column: "PetitionByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDisciplinaryActions_PortfolioIncidents_PortfolioIncidentId",
                table: "PortfolioDisciplinaryActions",
                column: "PortfolioIncidentId",
                principalTable: "PortfolioIncidents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                table: "PortfolioDisciplinaryActions",
                column: "ImposedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_PortfolioProviders_PortfolioProviderId",
                table: "PortfolioEntries",
                column: "PortfolioProviderId",
                principalTable: "PortfolioProviders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_PortfolioScopes_PortfolioScopeId",
                table: "PortfolioEntries",
                column: "PortfolioScopeId",
                principalTable: "PortfolioScopes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_PortfolioTypes_PortfolioTypeId",
                table: "PortfolioEntries",
                column: "PortfolioTypeId",
                principalTable: "PortfolioTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "PortfolioEntries",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_SkillsFrameworkSkills_SfSkillsId",
                table: "PortfolioEntries",
                column: "SfSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioEntries_Users_UserId",
                table: "PortfolioEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioIncidents_PortfolioIncidentTypes_PortfolioIncidentTypeId",
                table: "PortfolioIncidents",
                column: "PortfolioIncidentTypeId",
                principalTable: "PortfolioIncidentTypes",
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
                name: "FK_PortfolioProviders_SectorDisciplines_SectorDisciplineId",
                table: "PortfolioProviders",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_PortfolioSessions_PortfolioSessionId",
                table: "PortfolioSessionInvolved",
                column: "PortfolioSessionId",
                principalTable: "PortfolioSessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessionInvolved_Users_UserId",
                table: "PortfolioSessionInvolved",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSessions_PortfolioSessionTypes_PortfolioSessionTypeId",
                table: "PortfolioSessions",
                column: "PortfolioSessionTypeId",
                principalTable: "PortfolioSessionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAttendances_Schedules_ScheduleId",
                table: "ScheduleAttendances",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAttendances_Users_AnyUserId",
                table: "ScheduleAttendances",
                column: "AnyUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleMerges_Schedules_ScheduleId",
                table: "ScheduleMerges",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                table: "Schedules",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Courses_CourseId",
                table: "Schedules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Cycles_CycleId",
                table: "Schedules",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Rooms_RoomId",
                table: "Schedules",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_EnrollmentRoles_EnrollmentRoleId",
                table: "ScheduleTeachers",
                column: "EnrollmentRoleId",
                principalTable: "EnrollmentRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_Schedules_ScheduleId",
                table: "ScheduleTeachers",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleTeachers_Users_TeacherUserId",
                table: "ScheduleTeachers",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipApplications_ScholarshipCycleLimits_ScholarshipCycleLimitId",
                table: "ScholarshipApplications",
                column: "ScholarshipCycleLimitId",
                principalTable: "ScholarshipCycleLimits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                table: "ScholarshipApplications",
                column: "ApplicantUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipCycleLimits_Cycles_CycleId",
                table: "ScholarshipCycleLimits",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipCycleLimits_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipCycleLimits",
                column: "ScholarshipListId",
                principalTable: "ScholarshipLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipApplications_ScholarshipApplicationId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipApplicationId",
                principalTable: "ScholarshipApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_ScholarshipRequirements_ScholarshipRequirementId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipRequirementId",
                principalTable: "ScholarshipRequirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                table: "ScholarshipEvaluations",
                column: "EvaluatorUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipRequirements_Requirements_RequirementId",
                table: "ScholarshipRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipRequirements_ScholarshipLists_ScholarshipListId",
                table: "ScholarshipRequirements",
                column: "ScholarshipListId",
                principalTable: "ScholarshipLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                table: "SectorDisciplines",
                column: "ParentId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCompetencyCategories_SkillsFrameworkCompetencyTypes_SfCompetencyTypeId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SfCompetencyTypeId",
                principalTable: "SkillsFrameworkCompetencyTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_Courses_CourseId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "SkillsFrameworkSkillsToCompetencyId",
                principalTable: "SkillsFrameworkSkillsToCompetencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleJobRoles_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                table: "SkillsFrameworkJobRoleJobRoles",
                column: "SfTrackSpecializationId",
                principalTable: "SkillsFrameworkTrackSpecializations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkCriticalWorkFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleToCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfJobRoleToCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SkillsFrameworkSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkKeyTasks_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkKeyTasks",
                column: "SfCriticalWorkFunctionId",
                principalTable: "SkillsFrameworkCriticalWorkFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfJobRoleId",
                principalTable: "SkillsFrameworkJobRoleJobRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkPerformanceExpectations_SfPerformanceExpectationId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfPerformanceExpectationId",
                principalTable: "SkillsFrameworkPerformanceExpectations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkProficiencyLevels_SkillsFrameworkGroupLevels_SfGroupLevelId",
                table: "SkillsFrameworkProficiencyLevels",
                column: "SfGroupLevelId",
                principalTable: "SkillsFrameworkGroupLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkills_SkillsFrameworkCompetencyCategories_SfCompetencyCategoryId",
                table: "SkillsFrameworkSkills",
                column: "SfCompetencyCategoryId",
                principalTable: "SkillsFrameworkCompetencyCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkCompetencies_SfCompetencyId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfCompetencyId",
                principalTable: "SkillsFrameworkCompetencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfProficiencyLevelId",
                principalTable: "SkillsFrameworkProficiencyLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkills_SfSkillsId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfSkillsId",
                principalTable: "SkillsFrameworkSkills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsFrameworkTrackSpecializations_SectorDisciplines_SectorDisciplineId",
                table: "SkillsFrameworkTrackSpecializations",
                column: "SectorDisciplineId",
                principalTable: "SectorDisciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableObjects_AccountGroups_AccountGroupId",
                table: "TableObjects",
                column: "AccountGroupId",
                principalTable: "AccountGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableObjects_TableObjects_ParentId",
                table: "TableObjects",
                column: "ParentId",
                principalTable: "TableObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                table: "TemplateGradeBookItemDetails",
                column: "EqaAssessmentTypeId",
                principalTable: "EducationalQualityAssuranceAssessmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItemDetails_TemplateGradeBookItems_TemplateGradeBookItemId",
                table: "TemplateGradeBookItemDetails",
                column: "TemplateGradeBookItemId",
                principalTable: "TemplateGradeBookItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItems_GradingPeriods_GradingPeriodId",
                table: "TemplateGradeBookItems",
                column: "GradingPeriodId",
                principalTable: "GradingPeriods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateGradeBookItems_TemplateGradeBooks_TemplateGradeBookId",
                table: "TemplateGradeBookItems",
                column: "TemplateGradeBookId",
                principalTable: "TemplateGradeBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessGroupDetails_AccessGroupActions_AccessGroupActionId",
                table: "UserAccessGroupDetails",
                column: "AccessGroupActionId",
                principalTable: "AccessGroupActions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessGroupDetails_Users_UserId",
                table: "UserAccessGroupDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampusDetails_Campuses_CampusId",
                table: "UserCampusDetails",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampusDetails_Users_UserId",
                table: "UserCampusDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherApplied_EnrollmentBillings_EnrollmentBillingId",
                table: "VoucherApplied",
                column: "EnrollmentBillingId",
                principalTable: "EnrollmentBillings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherApplied_Vouchers_VoucherId",
                table: "VoucherApplied",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id");
        }
    }
}
