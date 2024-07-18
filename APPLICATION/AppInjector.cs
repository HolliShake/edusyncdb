using APPLICATION.Jwt;
using APPLICATION.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace APPLICATION;
public class AppInjector
{
    public static void Inject(IServiceCollection services, ConfigurationManager configuration)
    {
        // AutoMaper
        #region AUTOMAPPER
            services.AddAutoMapper(typeof(UserMapper));
			services.AddAutoMapper(typeof(AgencyMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CampusMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CycleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AcademicCalendarMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradingPeriodMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AcademicTermMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionApplicantMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AcademicProgramMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CollegeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionApplicationMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionScheduleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionEvaluationScheduleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(RequirementMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionProgramRequirementMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AdmissionScoreMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(BuildingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(FileManagerMapper));
			services.AddAutoMapper(typeof(RoomMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ProgramTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CurriculumMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeInputMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CourseMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SectorDisciplineMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CourseRequisiteMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(TableObjectMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AccountGroupMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(FundSourceMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentFeeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AccessListMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(AccessListActionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(BulletinMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(BulletinCategoryMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ClearanceTagMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ClearanceTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(BulletinScopeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CourseCreditingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(OtherSchoolMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CurriculumDetailMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceCourseObjectiveMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceEducationalGoalMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceLearningObjectiveMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceProgramObjectiveMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentRoleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentBillingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentLogMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentGradeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EnrollmentPaymentMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceProgramObjectiveToJobRoleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EducationalQualityAssuranceAssessmentTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EvaluationPeriodMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EvaluationRatingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(EvaluationRatingDetailMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ParameterMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ParameterSubCategoryMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ParameterCategoryMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(LikertQuestionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(InstrumentMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeBookMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeBookItemDetailMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeBookItemMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeBookScoreMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GradeBookItemToEqaLearningObjectiveMappingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GraduationApplicantMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(GraduationCampusMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PetitionCoursesMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CourseFeeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(CourseToLearningObjectiveMappingMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(FileTableMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScheduleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScheduleAttendanceMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScheduleMergeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScheduleTeacherMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioDisciplinaryActionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioEntryMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioIncidentMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioIncidentTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioProviderMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioScopeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioSessionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioSessionInvolvedMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioSessionTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(PortfolioTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScholarshipApplicationMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScholarshipCycleLimitMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScholarshipEvaluationMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScholarshipListMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(ScholarshipRequirementMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkCompetencyMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkCompetencyCategoryMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkCompetencyTypeMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkCourseToCompetencyMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkCriticalWorkFunctionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkGroupLevelMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkJobRoleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkJobRoleToCriticalWorkFunctionMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkJobRoleToProficiencyLevelMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkKeyTaskMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkPerformaceExpectationToJobRoleMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkPerformanceExpectationMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkProficiencyLevelMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkSkillsMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkSkillsToCompetencyMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(SkillsFrameworkTrackSpecializationMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(VoucherMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(VoucherAppliedMapper)); /* added by make.py */
			services.AddAutoMapper(typeof(UserAccessMapper)); /* added by make.py */
		#endregion

        // Jwt
        var cfg = new JwtTokenConfig(
            configuration["Jwt:SecretKey"],
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"]
        );

        services.AddSingleton(cfg);
        services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
        services.AddHostedService<JwtRefreshTokenCache>();

        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.RequireHttpsMetadata = true;
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(cfg.SecurityKey),
                ValidIssuer = cfg.Issuer,
                ValidAudience = cfg.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(0)
            };
        });
    }
}