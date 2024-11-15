using DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace INFRASTRUCTURE.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    // A
    public DbSet<AcademicCalendar> AcademicCalendars { get; set; }
    public DbSet<AcademicProgram> AcademicPrograms { get; set; }
    public DbSet<AcademicProgramChair> AcademicProgramChairs { get; set; }
    public DbSet<AcademicTerm> AcademicTerms { get; set; }
    public DbSet<AccountGroup> AccountGroups { get; set; }
    public DbSet<AccessGroup> AccessGroups { get; set; }
    public DbSet<AccessGroupAction> AccessGroupActions { get; set; }
    public DbSet<AdmissionApplicant> AdmissionApplicants { get; set; }
    public DbSet<AdmissionApplicantFamilyDetails> AdmissionApplicantFamilyDetails { get; set; }
    public DbSet<AdmissionApplication> AdmissionApplications { get; set; }
    public DbSet<AdmissionEvaluationSchedule> AdmissionEvaluationSchedules { get; set; }
    public DbSet<AdmissionProgramRequirement> AdmissionProgramRequirements { get; set; }
    public DbSet<AdmissionSchedule> AdmissionSchedules { get; set; }
    public DbSet<AdmissionScore> AdmissionScores { get; set; }
    public DbSet<Agency> Agencies { get; set; }
    // B
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Bulletin> Bulletins { get; set; }
    public DbSet<BulletinCategory> BulletinCategories { get; set; }
    public DbSet<BulletinScope> BulletinScopes { get; set; }
    // C
    public DbSet<Campus> Campuses { get; set; }
    public DbSet<ClearanceTag> ClearanceTags { get; set; }
    public DbSet<ClearanceType> ClearanceTypes { get; set; }
    public DbSet<College> Colleges { get; set; }
    public DbSet<CollegeDean> CollegeDeans { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseCrediting> CourseCreditings { get; set; }
    public DbSet<CourseFee> CourseFees { get; set; }
    public DbSet<CourseRequisite> CourseRequisites { get; set; }
    public DbSet<CourseToLearningObjectiveMapping> CourseToLearningObjectiveMappings { get; set; }
    public DbSet<Curriculum> Curricula { get; set; }
    public DbSet<CurriculumDetail> CurriculumDetails { get; set; }
    public DbSet<Cycle> Cycles { get; set; }
    // E
    public DbSet<EducationalQualityAssuranceAssessmentType> EducationalQualityAssuranceAssessmentTypes { get; set; }
    public DbSet<EducationalQualityAssuranceCourseObjective> EducationalQualityAssuranceCourseObjectives { get; set; }
    public DbSet<EducationalQualityAssuranceEducationalGoal> EducationalQualityAssuranceEducationalGoals { get; set; }
    public DbSet<EducationalQualityAssuranceLearningObjective> EducationalQualityAssuranceLearningObjectives { get; set; }
    public DbSet<EducationalQualityAssuranceProgramObjective> EducationalQualityAssuranceProgramObjectives { get; set; }
    public DbSet<EducationalQualityAssuranceProgramObjectiveToJobRole> EducationalQualityAssuranceProgramObjectiveToJobRoles { get; set; }
    public DbSet<EducationalQualityAssuranceType> EducationalQualityAssuranceTypes { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<EnrollmentBilling> EnrollmentBillings { get; set; }
    public DbSet<EnrollmentFee> EnrollmentFees { get; set; }
    public DbSet<EnrollmentGrade> EnrollmentGrades { get; set; }
    public DbSet<EnrollmentLog> EnrollmentLogs { get; set; }
    public DbSet<EnrollmentPayment> EnrollmentPayments { get; set; }
    public DbSet<EnrollmentRole> EnrollmentRoles { get; set; }
    public DbSet<EvaluationPeriod> EvaluationPeriods { get; set; }
    public DbSet<EvaluationRating> EvaluationRatings { get; set; }
    public DbSet<EvaluationRatingDetail> EvaluationRatingDetails { get; set; }
    // F
    public DbSet<FileTable> FileTables { get; set; }
    public DbSet<FundSource> FundSources { get; set; }
    // G
    public DbSet<GradeBook> GradeBooks { get; set; }
    public DbSet<GradeBookItem> GradeBookItems { get; set; }
    public DbSet<GradeBookItemDetail> GradeBookItemDetails { get; set; }
    public DbSet<GradeBookItemToEqaLearningObjectiveMapping> GradeBookItemToEqaLearningObjectiveMappings { get; set; }
    public DbSet<GradeBookScore> GradeBookScores { get; set; }
    public DbSet<GradeInput> GradeInputs { get; set; }
    public DbSet<GradingPeriod> GradingPeriods { get; set; }
    public DbSet<GraduationApplicant> GraduationApplicants { get; set; }
    public DbSet<GraduationCampus> GraduationCampuses { get; set; }
    // I
    public DbSet<Instrument> Instruments { get; set; }
    // L
    public DbSet<LikertQuestion> LikertQuestions { get; set; }
    // O
    public DbSet<OtherSchool> OtherSchools { get; set; }
    // P
    public DbSet<DOMAIN.Model.Parameter> Parameters { get; set; }
    public DbSet<ParameterCategory> ParameterCategories { get; set; }
    public DbSet<ParameterSubCategory> ParameterSubCategories { get; set; }
    public DbSet<PetitionCourses> PetitionCourses { get; set; }
    public DbSet<PortfolioDisciplinaryAction> PortfolioDisciplinaryActions { get; set; }
    public DbSet<PortfolioEntry> PortfolioEntries { get; set; }
    public DbSet<PortfolioIncident> PortfolioIncidents { get; set; }
    public DbSet<PortfolioIncidentType> PortfolioIncidentTypes { get; set; }
    public DbSet<PortfolioProvider> PortfolioProviders { get; set; }
    public DbSet<PortfolioScope> PortfolioScopes { get; set; }
    public DbSet<PortfolioSession> PortfolioSessions { get; set; }
    public DbSet<PortfolioSessionInvolved> PortfolioSessionInvolved { get; set; }
    public DbSet<PortfolioSessionType> PortfolioSessionTypes { get; set; }
    public DbSet<PortfolioType> PortfolioTypes { get; set; }
    public DbSet<ProgramType> ProgramTypes { get; set; }
    // R
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<Room> Rooms { get; set; }
    // S
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<ScheduleAssignment> ScheduleAssignments { get; set; }
    public DbSet<ScheduleAttendance> ScheduleAttendances { get; set; }
    public DbSet<ScheduleMerge> ScheduleMerges { get; set; }
    public DbSet<ScheduleTeacher> ScheduleTeachers { get; set; }
    public DbSet<ScholarshipApplication> ScholarshipApplications { get; set; }
    public DbSet<ScholarshipCycleLimit> ScholarshipCycleLimits { get; set; }
    public DbSet<ScholarshipEvaluation> ScholarshipEvaluations { get; set; }
    public DbSet<ScholarshipList> ScholarshipLists { get; set; }
    public DbSet<ScholarshipRequirement> ScholarshipRequirements { get; set; }
    public DbSet<SectorDiscipline> SectorDisciplines { get; set; }
    public DbSet<SkillsFrameworkCompetency> SkillsFrameworkCompetencies { get; set; }
    public DbSet<SkillsFrameworkCompetencyCategory> SkillsFrameworkCompetencyCategories { get; set; }
    public DbSet<SkillsFrameworkCompetencyType> SkillsFrameworkCompetencyTypes { get; set; }
    public DbSet<SkillsFrameworkCourseToCompetency> SkillsFrameworkCourseToCompetencies { get; set; }
    public DbSet<SkillsFrameworkCriticalWorkFunction> SkillsFrameworkCriticalWorkFunctions { get; set; }
    public DbSet<SkillsFrameworkGroupLevel> SkillsFrameworkGroupLevels { get; set; }
    public DbSet<SkillsFrameworkJobRole> SkillsFrameworkJobRoleJobRoles { get; set; }
    public DbSet<SkillsFrameworkJobRoleToCriticalWorkFunction> SkillsFrameworkJobRoleToCriticalWorkFunctions { get; set; }
    public DbSet<SkillsFrameworkJobRoleToProficiencyLevel> SkillsFrameworkJobRoleToProficiencyLevels { get; set; }
    public DbSet<SkillsFrameworkKeyTask> SkillsFrameworkKeyTasks { get; set; }
    public DbSet<SkillsFrameworkPerformaceExpectationToJobRole> SkillsFrameworkPerformaceExpectationToJobRoles { get; set; }
    public DbSet<SkillsFrameworkPerformanceExpectation> SkillsFrameworkPerformanceExpectations { get; set; }
    public DbSet<SkillsFrameworkProficiencyLevel> SkillsFrameworkProficiencyLevels { get; set; }
    public DbSet<SkillsFrameworkSkills> SkillsFrameworkSkills { get; set; }
    public DbSet<SkillsFrameworkSkillsToCompetency> SkillsFrameworkSkillsToCompetencies { get; set; }
    public DbSet<SkillsFrameworkTrackSpecialization> SkillsFrameworkTrackSpecializations { get; set; }
    // T
    public DbSet<TableObject> TableObjects { get; set; }
    public DbSet<TemplateGradeBook> TemplateGradeBooks { get; set; }
    public DbSet<TemplateGradeBookItem> TemplateGradeBookItems { get; set; }
    public DbSet<TemplateGradeBookItemDetail> TemplateGradeBookItemDetails { get; set; }
    // U
    public DbSet<User> Users { get; set; }
    public DbSet<UserCampusDetails> UserCampusDetails { get; set; }
    public DbSet<UserAccessGroupDetails> UserAccessGroupDetails { get; set; }
    // V
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<VoucherApplied> VoucherApplied { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var relationship in entity.GetForeignKeys())
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }

        // College Dean
        modelBuilder.Entity<CollegeDean>()
            .HasIndex(u => u.UserId)
            .IsUnique();

        // Program Chair
        modelBuilder.Entity<AcademicProgramChair>()
            .HasIndex(u => u.UserId)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}