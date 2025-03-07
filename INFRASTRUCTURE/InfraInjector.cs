﻿using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
// Service
using INFRASTRUCTURE.Service.AccountingData;
using INFRASTRUCTURE.Service.AdmissionData;
using INFRASTRUCTURE.Service.BillingAndFee;
using INFRASTRUCTURE.Service.BulletinData;
using INFRASTRUCTURE.Service.CoreData;
using INFRASTRUCTURE.Service.CourseCatalogData;
using INFRASTRUCTURE.Service.CurriculumData;
using INFRASTRUCTURE.Service.DesignationData;
using INFRASTRUCTURE.Service.EClearanceData;
using INFRASTRUCTURE.Service.EnrollmentData;
using INFRASTRUCTURE.Service.EPortfolioData;
using INFRASTRUCTURE.Service.EvaluationData;
using INFRASTRUCTURE.Service.FileManagerData;
using INFRASTRUCTURE.Service.GradeBookData;
using INFRASTRUCTURE.Service.GraduateData;
using INFRASTRUCTURE.Service.MappingData;
using INFRASTRUCTURE.Service.ObeAndCqi;
using INFRASTRUCTURE.Service.SchedulingData;
using INFRASTRUCTURE.Service.ScholarshipData;
using INFRASTRUCTURE.Service.SecurityData;
using INFRASTRUCTURE.Service.SurveyFormData;
using INFRASTRUCTURE.Service.TemplateData;
// IService
using APPLICATION.IService.AccountingData;
using APPLICATION.IService.AdmissionData;
using APPLICATION.IService.BillingAndFee;
using APPLICATION.IService.BulletinData;
using APPLICATION.IService.CoreData;
using APPLICATION.IService.CourseCatalogData;
using APPLICATION.IService.CurriculumData;
using APPLICATION.IService.DesignationData;
using APPLICATION.IService.EClearanceData;
using APPLICATION.IService.EnrollmentData;
using APPLICATION.IService.EPortfolioData;
using APPLICATION.IService.EvaluationData;
using APPLICATION.IService.FileManagerData;
using APPLICATION.IService.GradeBookData;
using APPLICATION.IService.GraduateData;
using APPLICATION.IService.MappingData;
using APPLICATION.IService.ObeAndCqi;
using APPLICATION.IService.SchedulingData;
using APPLICATION.IService.ScholarshipData;
using APPLICATION.IService.SecurityData;
using APPLICATION.IService.SurveyFormData;
using APPLICATION.IService.TemplateData;
//
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using APPLICATION.IService.SharedData;
using INFRASTRUCTURE.Service.SharedData;

namespace INFRASTRUCTURE;

public class InfraInjector
{
    public static void Inject(IServiceCollection services, ConfigurationManager configuration)
    {
        // Inject services
        #region SERVICES
            services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAgencyService, AgencyService>(); /* added by make.py */
			services.AddScoped<ICampusService, CampusService>(); /* added by make.py */
			services.AddScoped<ICycleService, CycleService>(); /* added by make.py */
			services.AddScoped<IAcademicCalendarService, AcademicCalendarService>(); /* added by make.py */
			services.AddScoped<IGradingPeriodService, GradingPeriodService>(); /* added by make.py */
			services.AddScoped<IAcademicTermService, AcademicTermService>(); /* added by make.py */
			services.AddScoped<IAdmissionApplicantService, AdmissionApplicantService>(); /* added by make.py */
			services.AddScoped<IAcademicProgramService, AcademicProgramService>(); /* added by make.py */
			services.AddScoped<ICollegeService, CollegeService>(); /* added by make.py */
			services.AddScoped<IAdmissionApplicationService, AdmissionApplicationService>(); /* added by make.py */
			services.AddScoped<IAdmissionScheduleService, AdmissionScheduleService>(); /* added by make.py */
			services.AddScoped<IAdmissionEvaluationScheduleService, AdmissionEvaluationScheduleService>(); /* added by make.py */
			services.AddScoped<IRequirementService, RequirementService>(); /* added by make.py */
			services.AddScoped<IAdmissionProgramRequirementService, AdmissionProgramRequirementService>(); /* added by make.py */
			services.AddScoped<IAdmissionScoreService, AdmissionScoreService>(); /* added by make.py */
			services.AddScoped<IBuildingService, BuildingService>(); /* added by make.py */
			services.AddScoped<IFileManagerService, FileManagerService>();
			services.AddScoped<IRoomService, RoomService>(); /* added by make.py */
			services.AddScoped<IProgramTypeService, ProgramTypeService>(); /* added by make.py */
			services.AddScoped<ICurriculumService, CurriculumService>(); /* added by make.py */
			services.AddScoped<IGradeInputService, GradeInputService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceTypeService, EducationalQualityAssuranceTypeService>(); /* added by make.py */
			services.AddScoped<ICourseService, CourseService>(); /* added by make.py */
			services.AddScoped<ISectorDisciplineService, SectorDisciplineService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkTrackSpecializationService, SkillsFrameworkTrackSpecializationService>(); /* added by make.py */
			services.AddScoped<ICourseRequisiteService, CourseRequisiteService>(); /* added by make.py */
			services.AddScoped<ITableObjectService, TableObjectService>(); /* added by make.py */
			services.AddScoped<IAccountGroupService, AccountGroupService>(); /* added by make.py */
			services.AddScoped<IFundSourceService, FundSourceService>(); /* added by make.py */
			services.AddScoped<IEnrollmentFeeService, EnrollmentFeeService>(); /* added by make.py */
			services.AddScoped<IBulletinService, BulletinService>(); /* added by make.py */
			services.AddScoped<IBulletinCategoryService, BulletinCategoryService>(); /* added by make.py */
			services.AddScoped<IClearanceTagService, ClearanceTagService>(); /* added by make.py */
			services.AddScoped<IClearanceTypeService, ClearanceTypeService>(); /* added by make.py */
			services.AddScoped<IBulletinScopeService, BulletinScopeService>(); /* added by make.py */
			services.AddScoped<ICourseCreditingService, CourseCreditingService>(); /* added by make.py */
			services.AddScoped<IOtherSchoolService, OtherSchoolService>(); /* added by make.py */
			services.AddScoped<ICurriculumDetailService, CurriculumDetailService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceCourseObjectiveService, EducationalQualityAssuranceCourseObjectiveService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceEducationalGoalService, EducationalQualityAssuranceEducationalGoalService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceLearningObjectiveService, EducationalQualityAssuranceLearningObjectiveService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceProgramObjectiveService, EducationalQualityAssuranceProgramObjectiveService>(); /* added by make.py */
			services.AddScoped<IEnrollmentService, EnrollmentService>(); /* added by make.py */
			services.AddScoped<IEnrollmentRoleService, EnrollmentRoleService>(); /* added by make.py */
			services.AddScoped<IEnrollmentBillingService, EnrollmentBillingService>(); /* added by make.py */
			services.AddScoped<IEnrollmentLogService, EnrollmentLogService>(); /* added by make.py */
			services.AddScoped<IEnrollmentGradeService, EnrollmentGradeService>(); /* added by make.py */
			services.AddScoped<IEnrollmentPaymentService, EnrollmentPaymentService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceProgramObjectiveToJobRoleService, EducationalQualityAssuranceProgramObjectiveToJobRoleService>(); /* added by make.py */
			services.AddScoped<IEducationalQualityAssuranceAssessmentTypeService, EducationalQualityAssuranceAssessmentTypeService>(); /* added by make.py */
			services.AddScoped<IEvaluationPeriodService, EvaluationPeriodService>(); /* added by make.py */
			services.AddScoped<IEvaluationRatingService, EvaluationRatingService>(); /* added by make.py */
			services.AddScoped<IEvaluationRatingDetailService, EvaluationRatingDetailService>(); /* added by make.py */
			services.AddScoped<IParameterService, ParameterService>(); /* added by make.py */
			services.AddScoped<IParameterSubCategoryService, ParameterSubCategoryService>(); /* added by make.py */
			services.AddScoped<IParameterCategoryService, ParameterCategoryService>(); /* added by make.py */
			services.AddScoped<ILikertQuestionService, LikertQuestionService>(); /* added by make.py */
			services.AddScoped<IInstrumentService, InstrumentService>(); /* added by make.py */
			services.AddScoped<IGradeBookService, GradeBookService>(); /* added by make.py */
			services.AddScoped<IGradeBookItemDetailService, GradeBookItemDetailService>(); /* added by make.py */
			services.AddScoped<IGradeBookItemService, GradeBookItemService>(); /* added by make.py */
			services.AddScoped<IGradeBookScoreService, GradeBookScoreService>(); /* added by make.py */
			services.AddScoped<IGradeBookItemToEqaLearningObjectiveMappingService, GradeBookItemToEqaLearningObjectiveMappingService>(); /* added by make.py */
			services.AddScoped<IGraduationApplicantService, GraduationApplicantService>(); /* added by make.py */
			services.AddScoped<IGraduationCampusService, GraduationCampusService>(); /* added by make.py */
			services.AddScoped<IPetitionCoursesService, PetitionCoursesService>(); /* added by make.py */
			services.AddScoped<ICourseFeeService, CourseFeeService>(); /* added by make.py */
			services.AddScoped<ICourseToLearningObjectiveMappingService, CourseToLearningObjectiveMappingService>(); /* added by make.py */
			services.AddScoped<IFileTableService, FileTableService>(); /* added by make.py */
			services.AddScoped<IScheduleAttendanceService, ScheduleAttendanceService>(); /* added by make.py */
			services.AddScoped<IScheduleService, ScheduleService>(); /* added by make.py */
			services.AddScoped<IScheduleMergeService, ScheduleMergeService>(); /* added by make.py */
			services.AddScoped<IScheduleTeacherService, ScheduleTeacherService>(); /* added by make.py */
			services.AddScoped<ISectorDisciplineService, SectorDisciplineService>(); /* added by make.py */
			services.AddScoped<IPortfolioDisciplinaryActionService, PortfolioDisciplinaryActionService>(); /* added by make.py */
			services.AddScoped<IPortfolioEntryService, PortfolioEntryService>(); /* added by make.py */
			services.AddScoped<IPortfolioIncidentService, PortfolioIncidentService>(); /* added by make.py */
			services.AddScoped<IPortfolioIncidentTypeService, PortfolioIncidentTypeService>(); /* added by make.py */
			services.AddScoped<IPortfolioProviderService, PortfolioProviderService>(); /* added by make.py */
			services.AddScoped<IPortfolioScopeService, PortfolioScopeService>(); /* added by make.py */
			services.AddScoped<IPortfolioSessionService, PortfolioSessionService>(); /* added by make.py */
			services.AddScoped<IPortfolioSessionInvolvedService, PortfolioSessionInvolvedService>(); /* added by make.py */
			services.AddScoped<IPortfolioSessionTypeService, PortfolioSessionTypeService>(); /* added by make.py */
			services.AddScoped<IPortfolioTypeService, PortfolioTypeService>(); /* added by make.py */
			services.AddScoped<IScholarshipApplicationService, ScholarshipApplicationService>(); /* added by make.py */
			services.AddScoped<IScholarshipCycleLimitService, ScholarshipCycleLimitService>(); /* added by make.py */
			services.AddScoped<IScholarshipEvaluationService, ScholarshipEvaluationService>(); /* added by make.py */
			services.AddScoped<IScholarshipListService, ScholarshipListService>(); /* added by make.py */
			services.AddScoped<IScholarshipRequirementService, ScholarshipRequirementService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkCompetencyService, SkillsFrameworkCompetencyService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkCompetencyCategoryService, SkillsFrameworkCompetencyCategoryService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkCompetencyTypeService, SkillsFrameworkCompetencyTypeService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkCourseToCompetencyService, SkillsFrameworkCourseToCompetencyService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkCriticalWorkFunctionService, SkillsFrameworkCriticalWorkFunctionService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkGroupLevelService, SkillsFrameworkGroupLevelService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkJobRoleService, SkillsFrameworkJobRoleService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkJobRoleToCriticalWorkFunctionService, SkillsFrameworkJobRoleToCriticalWorkFunctionService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkJobRoleToProficiencyLevelService, SkillsFrameworkJobRoleToProficiencyLevelService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkKeyTaskService, SkillsFrameworkKeyTaskService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkPerformaceExpectationToJobRoleService, SkillsFrameworkPerformaceExpectationToJobRoleService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkPerformanceExpectationService, SkillsFrameworkPerformanceExpectationService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkProficiencyLevelService, SkillsFrameworkProficiencyLevelService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkSkillsService, SkillsFrameworkSkillsService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkSkillsToCompetencyService, SkillsFrameworkSkillsToCompetencyService>(); /* added by make.py */
			services.AddScoped<ISkillsFrameworkTrackSpecializationService, SkillsFrameworkTrackSpecializationService>(); /* added by make.py */
			services.AddScoped<IVoucherService, VoucherService>(); /* added by make.py */
			services.AddScoped<IVoucherAppliedService, VoucherAppliedService>(); /* added by make.py */
			services.AddScoped<IAccessGroupService, AccessGroupService>(); /* added by doydoy */
			services.AddScoped<IUserCampusDetailsService, UserCampusDetailsService>(); /* added by make.py */
			services.AddScoped<IAccessGroupActionService, AccessGroupActionService>(); /* added by make.py */
			services.AddScoped<IUserAccessGroupDetailsService, UserAccessGroupDetailsService>(); /* added by make.py */
			services.AddScoped<IAdmissionApplicantFamilyDetailsService, AdmissionApplicantFamilyDetailsService>(); /* added by make.py */
			services.AddScoped<IAdmissionEducationalBackgroundService, AdmissionEducationalBackgroundService>(); /* added by make.py */
			services.AddScoped<ITemplateGradeBookService, TemplateGradeBookService>(); /* added by make.py */
			services.AddScoped<ITemplateGradeBookItemService, TemplateGradeBookItemService>(); /* added by make.py */
			services.AddScoped<ITemplateGradeBookItemDetailService, TemplateGradeBookItemDetailService>(); /* added by make.py */
			services.AddScoped<IScheduleAssignmentService, ScheduleAssignmentService>(); /* added by make.py */
			services.AddScoped<IAcademicProgramChairService, AcademicProgramChairService>(); /* added by make.py */
			services.AddScoped<ICollegeDeanService, CollegeDeanService>(); /* added by make.py */
			services.AddScoped<ISpecializationChairService, SpecializationChairService>(); /* added by make.py */
			services.AddScoped<ICampusSchedulerService, CampusSchedulerService>(); /* added by make.py */
			services.AddScoped<ICampusRegistrarService, CampusRegistrarService>(); /* added by make.py */
			services.AddScoped<ISharedData, SharedData>(); /* added by doy */
			services.AddScoped<IVisionService, VisionService>(); /* added by doy */
			services.AddScoped<IMissionService, MissionService>(); /* added by doy */
        	services.AddScoped<IGraduateAttributesService, GraduateAttributesService>(); /* added by make.py */
		#endregion

        // Identity
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider)
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
            options.User.RequireUniqueEmail = true;
        });

        // Newton soft json
        services.AddControllers()
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
    }
}