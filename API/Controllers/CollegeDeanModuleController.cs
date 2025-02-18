using APPLICATION.IService.DesignationData;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollegeDeanModuleController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ICollegeDeanService _collegeDeanService;

    public CollegeDeanModuleController(
        IJwtAuthManager jwtAuthManager,
        ICollegeDeanService collegeDeanService
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _collegeDeanService = collegeDeanService;
    }

    /// <summary>
    /// Get current user college id
    /// </summary>
    /// <returns>int</returns>
    protected int GetCollegeId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("CampudId"))?.Value ?? "0");
    }

    /// <summary>
    /// Get all college deans.
    /// </summary>
    /// <returns></returns>
    /// <operationId>academicProgramChairMy</operationId>
    [HttpGet("AcademicProgramChair/My")]
    public async Task<ActionResult> GetAllAcademicProgramChair()
    {
        var collegeId = GetCollegeId();
        return Ok(await _collegeDeanService.GetAllProgramChairByCollegeId(collegeId));
    }

    /// <summary>
    /// Get all students in this college.
    /// </summary>
    /// <returns></returns>
    /// <operationId>studentsMy</operationId>
    [HttpGet("Students/My")]
    public async Task<ActionResult> GetAllStudentsByCollegeId()
    {
        var collegeId = GetCollegeId();
        return Ok(await _collegeDeanService.GetStudentByCollegeId(collegeId));
    }

    /// <summary>
    /// Get all teachers in this college.
    /// </summary>
    /// <returns></returns>
    /// <operationId>teachersMy</operationId>
    [HttpGet("Teachers/My")]
    public async Task<ActionResult> GetAllTeachersByCollegeId()
    {
        var collegeId = GetCollegeId();
        return Ok(await _collegeDeanService.GetTeacherByCollegeId(collegeId));
    }

    /// <summary>
    /// Get all students with eclerance status
    /// </summary>
    /// <returns></returns>
    /// <operationId>studentEClearanceMy</operationId>
    [HttpGet("EClearance/Students/My")]
    public async Task<ActionResult> GetStudentsEClearanceWithStatus()
    {
        var collegeId = GetCollegeId();
        return Ok(await _collegeDeanService.GetStudentsWithUnClearedStatus(collegeId));
    }

    /// <summary>
    /// Get all curriculum group by academic program
    /// </summary>
    /// <returns></returns>
    /// <operationId>academicProgramCurriculumMy</operationId>
    [HttpGet("Curriculum/AcademicProgram/My")]
    public async Task<ActionResult> GetCurriculumAcademicProgram()
    {
        var collegeId = GetCollegeId();
        return Ok(await _collegeDeanService.GetCurriculumPerAcademicProgramByCollegeId(collegeId));
    }
}