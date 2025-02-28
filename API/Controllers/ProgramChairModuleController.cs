using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using APPLICATION.IService.DesignationData;
using APPLICATION.IService.SharedData;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramChairModuleController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IAcademicProgramChairService _academicProgramChairService;
    private readonly ISharedData _sharedData;

    public ProgramChairModuleController(
        IJwtAuthManager jwtAuthManager,
        IAcademicProgramChairService academicProgramChairService,
        ISharedData sharedDataService
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _academicProgramChairService = academicProgramChairService;
        _sharedData = sharedDataService;
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

    /// <summary>
    /// Get current user Academic Program Id
    /// </summary>
    /// <returns></returns>
    protected int GetAcademicProgramId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("AcademicProgramId"))?.Value ?? "0");
    }

    /// <summary>
    /// Get all academic programs where I am the chairman.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Students/My")]
    public async Task<ActionResult> GetAllAcademicProgramsAction([FromQuery] int page=1, [FromQuery] int rows=10)
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _sharedData.GetStudentsByContext(
            academicProgramId,
            page,
            rows,
            ContextType.ProgramChair
        ));
    }

    /// <summary>
    /// Get all teachers in my academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Teachers/My")]
    public async Task<ActionResult> GetTeachersByAcademicProgram([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _sharedData.GetTeachersByContext(
            academicProgramId,
            page,
            rows,
            ContextType.ProgramChair
        ));
    }

    /// <summary>
    /// Get all courses in my academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ActiveCurriculum/Courses/My")]
    public async Task<ActionResult> GetActiveCurriculumCourses()
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _academicProgramChairService.GetActiveCurriculumCoursesByAcademicProgram(academicProgramId));
    }
    
    /// <summary>
    /// Get all curriculums in my academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Curriculum/My")]
    public async Task<ActionResult> GetCurriculumByUserId([FromQuery] int page = 1, [FromQuery] int rows = 10)
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _sharedData.GetCurriculumByContext(
            academicProgramId,
            page,
            rows,
            ContextType.ProgramChair
        ));
    }

    /// <summary>
    /// Get all sections in my academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ActiveCurriculum/Sections/My")]
    public async Task<ActionResult> GetActiveCurriculumSections()
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _academicProgramChairService.GetActiveCurriculumSectionsByAcademicProgram(academicProgramId));
    }

    /// <summary>
    /// Get all sections in my academic program, grouped by year level.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Curriculum/Sections/YearLevel/My/")]
    public async Task<ActionResult> GetCurriculumSectionsByYearLevel()
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _academicProgramChairService.GetActiveCurriculumSectionsByAcademicProgramGroupByYear(academicProgramId));
    }

    /// <summary>
    /// Get all evaluation under this academic program.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Evaluation/My")]
    public async Task<ActionResult> GetEvaluationMy()
    {
        var academicProgramId = GetAcademicProgramId();
        return Ok(await _academicProgramChairService.GetEvaluationByAcademicProgramId(academicProgramId));
    }
}