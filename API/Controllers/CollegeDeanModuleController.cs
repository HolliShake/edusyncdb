using APPLICATION.IService.DesignationData;
using APPLICATION.IService.SharedData;
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
    private readonly ISharedData _sharedData;

    public CollegeDeanModuleController(
        IJwtAuthManager jwtAuthManager,
        ICollegeDeanService collegeDeanService,
        ISharedData sharedData
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _collegeDeanService = collegeDeanService;
        _sharedData = sharedData;
    }

    /// <summary>
    /// Get current user college id
    /// </summary>
    /// <returns>int</returns>
    protected int GetCollegeId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("CollegeId"))?.Value ?? "0");
    }

    /// <summary>
    /// Get all academic program chair under my college.
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
    /// Get all student in my college
    /// </summary>
    /// <returns></returns>
    [HttpGet("Students/My")]
    public async Task<ActionResult> GetAllAcademicProgramsAction([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {
        var collegeId = GetCollegeId();
        return Ok(await _sharedData.GetStudentsByContext(
            collegeId,
            page,
            rows,
            ContextType.CollegeDean
        ));
    }

    /// <summary>
    /// Get all teachers in my college.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Teachers/My")]
    public async Task<ActionResult> GetTeachersByAcademicProgram([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {
        var collegeId = GetCollegeId();
        return Ok(await _sharedData.GetTeachersByContext(
            collegeId,
            page,
            rows,
            ContextType.CollegeDean
        ));
    }

    /// <summary>
    /// Get all curriculums in my academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Curriculum/My")]
    public async Task<ActionResult> GetCurriculumByUserId([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {
        var collegeId = GetCollegeId();
        return Ok(await _sharedData.GetCurriculumByContext(
            collegeId,
            page,
            rows,
            ContextType.CollegeDean
        ));
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