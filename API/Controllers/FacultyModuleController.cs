using APPLICATION.IService;
using APPLICATION.Jwt;
using DOMAIN.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class FacultyModuleController:ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IScheduleTeacherService _scheduleTeacher;
    private readonly IEnrollmentService _enrollment;
    private readonly IUserCampusDetailsService _userCampus;
    private readonly IScheduleAttendanceService _scheduleAttendance;
    public FacultyModuleController(
        IJwtAuthManager jwtAuthManager,
        IScheduleTeacherService scheduleTeacher,
        IEnrollmentService enrollment,
        IUserCampusDetailsService userCampus,
        IScheduleAttendanceService scheduleAttendance
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _scheduleTeacher = scheduleTeacher;
        _enrollment = enrollment;
        _userCampus = userCampus;
        _scheduleAttendance = scheduleAttendance;
    }

    /// <summary>
    /// Get current user User Id
    /// </summary>
    /// <returns></returns>
    protected string GetUserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get current loggedin faculty schedules.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpGet("Schedules/My")]
    public async Task<ActionResult> GetCurrentFacultySchedules()
    {
        var userId = GetUserId();
        return Ok(await _scheduleTeacher.GetScheduleTeacherByUserId(userId));
    }

    /// <summary>
    /// Get current loggedin faculty gradebook.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpGet("GradeBook/My")]
    public async Task<ActionResult> GetCurrentFacultyGradeBook()
    {
        var userId = GetUserId();
        return Ok(await _scheduleTeacher.GetTeacherScheduleGradeBookByUserId(userId));
    }

    /// <summary>
    /// Get current loggedin faculty gradebook by Academic Program Id.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpGet("GradeBook/My/AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetCurrentFacultyGradeBook(int academicProgramId)
    {
        var userId = GetUserId();
        return Ok(await _scheduleTeacher.GetTeacherScheduleGradeBookByUserIdAndAcademicProgramId(userId, academicProgramId));
    }

    /// <summary>
    /// Get currents user enrolled student by schedule id (pass id from "Schedules/My").
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <returns>Array[Enrollment]</returns>
    [HttpGet("Students/My/{scheduleId:int}")]
    public async Task<ActionResult> GetEnrolledStudentByScheduleId(int scheduleId)
    {
        var userId = GetUserId();
        if (!(await _scheduleTeacher.HasShedule(userId, scheduleId)))
        {
            return NotFound("Schedule not found for user!");
        }
        return Ok(await _enrollment.GetEnrollmentsWithScoreByScheduleId(scheduleId));
    }

    /// <summary>
    /// Get all campus that I have access.
    /// </summary>
    /// <returns>Array[UserCampus]</returns>
    [HttpGet("CampusAccess/My")]
    public async Task<ActionResult> GetFacultyCampusAccess()
    {
        var userId = GetUserId();
        return Ok(await _scheduleTeacher.GetTeacherScheduleWhereHeOrSheTeach(userId));
    }

    /// <summary>
    /// Get all academic program that I have access.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns></returns>
    [HttpGet("AcademicProgram/Campus/{campusId:int}/My")]
    public async Task<ActionResult> GetFacultyAcademicProgram(int campusId)
    {
        var userId = GetUserId();
        return Ok(await _scheduleTeacher.GetAcademicProgramByUserAndCampusId(userId, campusId));
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
}