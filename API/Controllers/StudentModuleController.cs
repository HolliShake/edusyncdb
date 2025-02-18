using API.Attributes;
using APPLICATION.IService;
using APPLICATION.Jwt;
using DOMAIN.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using APPLICATION.IService.CourseCatalogData;
using APPLICATION.IService.EClearanceData;
using APPLICATION.IService.EnrollmentData;
using APPLICATION.IService.EvaluationData;
using APPLICATION.IService.SchedulingData;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentModuleController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IEnrollmentService _enrollment;
    private readonly IEnrollmentGradeService _enrollmentGrade;
    private readonly IScheduleAttendanceService _scheduleAttendance;
    private readonly IClearanceTagService _clearanceTagService;
    private readonly IEvaluationPeriodService _evaluationPeriodService;
    private readonly ICourseCreditingService _courseCreditingService;

    public StudentModuleController(
        IJwtAuthManager jwtAuthManager,
        IEnrollmentService enrollment,
        IEnrollmentGradeService enrollmentGrade,
        IScheduleAttendanceService scheduleAttendance,
        IClearanceTagService clearanceTagService,
        IEvaluationPeriodService evaluationPeriodService,
        ICourseCreditingService courseCreditingService
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _enrollment = enrollment;
        _enrollmentGrade = enrollmentGrade;
        _scheduleAttendance = scheduleAttendance;
        _clearanceTagService = clearanceTagService;
        _evaluationPeriodService = evaluationPeriodService;
        _courseCreditingService = courseCreditingService;
    }

    /// <summary>
    /// Get current user User Id
    /// </summary>
    /// <returns>string</returns>
    protected string GetUserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

    /// <summary>
    /// Get schedule. (for dashboard display)
    /// </summary>
    /// <returns></returns>
    [HttpGet("Dashboard/TodaySchedules/My")]
    public async Task<ActionResult> GetDashboardSchedules()
    {
        var userId = GetUserId();
        return Ok(await _enrollment.GetUserTodaysScheduleIfEnrolled(userId));
    }

    /// <summary>
    /// Get enrolled course with schedule. (for dashboard display)
    /// </summary>
    /// <returns></returns>
    [HttpGet("Dashboard/EnrolledCourseSchedule")]
    public async Task<ActionResult> GetDashboardEnrolledCourse()
    {
        var userId = GetUserId();
        return Ok(await _enrollment.GetUserTodaysScheduleIfEnrolled(userId));
    }

    /// <summary>
    /// Get Enrolled courses
    /// </summary>
    /// <returns></returns>
    [HttpGet("CoursesEnrolled/My")]
    public async Task<ActionResult> GetCourseEnrolled()
    {
        var userId = GetUserId();
        return Ok(await _enrollment.GetEnrollmentsByStudentUserId(userId));
    }

    /// <summary>
    /// Get Current user's Grades
    /// </summary>
    /// <returns>Array[object]</returns>
    [Casl("Admin:read", "Student:read")]
    [HttpGet("Grades/My")]
    public async Task<ActionResult> GetGrades()
    {
        var userId = GetUserId();
        return Ok(await _enrollmentGrade.GetPostedGradesByStudentUserId(userId));
    }

    /// <summary>
    /// Get Current user's assessment.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Assessments/My")]
    public async Task<ActionResult> GetAssessments()
    {
        var userId = GetUserId();
        return Ok(await _enrollmentGrade.GetAssessmentsByStudentUserId(userId));
    }

    /// <summary>
    /// Get Current user's attendance.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Attendance/My")]
    public async Task<ActionResult> GetAttendance()
    {
        var userId = GetUserId();
        return Ok(await _scheduleAttendance.GetAttendanceByAnyUserId(userId));
    }

    /// <summary>
    /// Get Current user's e-clearance tag.
    /// </summary>
    /// <returns></returns>
    [HttpGet("EClearance/Tag/My")]
    public async Task<ActionResult> GetEClearanceTag()
    {
        var userId = GetUserId();
        return Ok(await _clearanceTagService.GetEClearanceTagByStudentUserId(userId));
    }

    /// <summary>
    /// Get current user's evaluation.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FacultyEvaluation/My")]
    public async Task<ActionResult> GetMyOpenEvaluation()
    {
        var userId = GetUserId();
        return Ok(await _evaluationPeriodService.GetOpenEvaluationPeriodByEnrollmentUserId(userId));
    }

    /// <summary>
    /// Get current user's un-evaluated faculty.
    /// </summary>
    /// <param name="evaluationPeriodId"></param>
    /// <returns></returns>
    [HttpGet("FacultyEvaluation/UnEvaluatedFaculty/EvaluationPeriod/{evaluationPeriodId:int}/My")]
    public async Task<ActionResult> GetMyUnEvaluatedFaculty(int evaluationPeriodId)
    {
        var userId = GetUserId();
        return Ok(await _evaluationPeriodService.GetAllEvaluationTeachsByEvaluationPeriodAndUserId(userId, evaluationPeriodId));
    }

    /// <summary>(
    /// Get current's user approved course crediting.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Pending/My")]
    public async Task<ActionResult> GetMyPendingCourseCrediting()
    {
        var userId = GetUserId();
        return Ok(await _courseCreditingService.GetCourseCreditingByStatusAndAssignToUserId(GlobalValidityStatusEnum.PENDING, userId));
    }

    /// <summary>
    /// Get current's user approved course crediting.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Approved/My")]
    public async Task<ActionResult> GetMyApprovedCourseCrediting()
    {
        var userId = GetUserId();
        return Ok(await _courseCreditingService.GetCourseCreditingByStatusAndAssignToUserId(GlobalValidityStatusEnum.APPROVED, userId));
    }

    /// <summary>
    /// Get current's user approved course crediting.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Rejected/My")]
    public async Task<ActionResult> GetMyRejectedCourseCrediting()
    {
        var userId = GetUserId();
        return Ok(await _courseCreditingService.GetCourseCreditingByStatusAndAssignToUserId(GlobalValidityStatusEnum.REJECTED, userId));
    }
}