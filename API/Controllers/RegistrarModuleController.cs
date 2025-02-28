using APPLICATION.IService.CoreData;
using APPLICATION.IService.CourseCatalogData;
using APPLICATION.IService.EnrollmentData;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RegistrarModuleController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ICycleService _cycleService;
    private readonly IEnrollmentService _enrollmentService;
    private readonly ICourseService _courseService;
    private readonly IAcademicProgramService _academicProgram;

    public RegistrarModuleController(
        IJwtAuthManager jwtAuthManager,
        ICycleService cycleService,
        IEnrollmentService enrollmentService,
        ICourseService courseService,
        IAcademicProgramService academicProgram
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _cycleService = cycleService;
        _enrollmentService = enrollmentService;
        _courseService = courseService;
        _academicProgram = academicProgram;
    }

    /// <summary>
    /// Get current user campus id
    /// </summary>
    /// <returns>int</returns>
    protected int GetCampusId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("CampusId"))?.Value ?? "0");
    }

    /// <summary>
    /// Get campus cycles (school year) where I am the registrar
    /// </summary>
    /// <returns>Array[Cycles]</returns>
    [HttpGet("Campus/Cycles/My")]
    public async Task<ActionResult> GetMyCampusCycle()
    {
        return Ok(await _cycleService.GetCycleByCampusId(GetCampusId()));
    }
    
    /// <summary>
    /// Get students with clearance status, paginated
    /// </summary>
    /// <param name="studentFullname"></param>
    /// <param name="Page"></param>
    /// <param name="Rows"></param>
    /// <returns></returns>
    [HttpGet("Campus/EClearance/Students/My")]
    public async Task<ActionResult> GetMyStudentsInCampus(
        [FromQuery] string? studentFullname = null,
        [FromQuery] int? Page = 1,
        [FromQuery] int? Rows = 10
    )
    {
        return Ok(await _enrollmentService.GetEnrolledUserWithEClearanceTagByCampusIdPaginated(GetCampusId(), studentFullname, Page??1, Rows??10));
    }

    /// <summary>
    /// Get courses with requisite
    /// </summary>
    /// <returns></returns>
    [HttpGet("Campus/Course/My")]
    public async Task<ActionResult> GetMyCourses()
    {
        return Ok(await _courseService.GetAllWithRequisiteAsync());
    }

    /// <summary>
    /// Get academic Program in my campus
    /// </summary>
    /// <returns></returns>
    [HttpGet("Campus/AcademicProgram/My")]
    public async Task<ActionResult> GetMyProgram()
    {
        return Ok(await _academicProgram.GetAcademicProgramByCampusId(GetCampusId()));
    }
}
