using APPLICATION.Dto.EnrollmentGrade;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using APPLICATION.Jwt;
using System.Security.Claims;
using APPLICATION.IService.EnrollmentData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentGradeController : GenericController<EnrollmentGrade, IEnrollmentGradeService, EnrollmentGradeDto, GetEnrollmentGradeDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public EnrollmentGradeController(IMapper mapper, IEnrollmentGradeService repo, IJwtAuthManager jwtAuthManager):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/

    /// <summary>
    /// Get current user id.
    /// </summary>
    /// <returns>string</returns>
    protected string GetUserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    
    /// <summary>
    /// Get specific data (EnrollmentGrade) by id.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }


    /// <summary>
    /// Post Enrollment Grade by schedule id.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <param name="gradingPeriodId"></param>
    /// <returns>Array[EnrollmentGrade]?</returns>
    [HttpPost("post/Schedule/{scheduleId:int}/GradingPeriod/{gradingPeriodId:int}")]
    public async Task<ActionResult> PostScheduleGrade(int scheduleId, int gradingPeriodId)
    {
        var userId = GetUserId();
        var result = await _repo.PostOrUnPostGradeByScheduleId(scheduleId, gradingPeriodId, userId, true);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to post grade");
    }

    /// <summary>
    /// Post Enrollment Grade by schedule id.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <param name="gradingPeriodId"></param>
    /// <returns>Array[EnrollmentGrade]?</returns>
    [HttpPut("unpost/Schedule/{scheduleId:int}/GradingPeriod/{gradingPeriodId:int}")]
    public async Task<ActionResult> UnPostScheduleGrade(int scheduleId, int gradingPeriodId)
    {
        var userId = GetUserId();
        var result = await _repo.PostOrUnPostGradeByScheduleId(scheduleId, gradingPeriodId, userId, false);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to unpost grade");
    }

    /// <summary>
    /// Post single enrollment grade.
    /// </summary>
    /// <param name="enrollmentId"></param>
    /// <param name="gradingPeriodId"></param>
    /// <returns></returns>
    [HttpPost("post/Enrollment/{enrollmentId:int}/GradingPeriod/{gradingPeriodId:int}")]
    public async Task<ActionResult> PostGrade(int enrollmentId, int gradingPeriodId)
    {
        var userId = GetUserId();
        var result = await _repo.PostOrUnPostGrade(enrollmentId, gradingPeriodId, userId, true);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to post grade");
    }

    /// <summary>
    /// UnPost single enrollment grade.
    /// </summary>
    /// <param name="enrollmentId"></param>
    /// <param name="gradingPeriodId"></param>
    /// <returns>EnrollmentGrade</returns>
    [HttpPut("unpost/Enrollment/{enrollmentId:int}/GradingPeriod/{gradingPeriodId:int}")]
    public async Task<ActionResult> UnPostGrade(int enrollmentId, int gradingPeriodId)
    {
        var userId = GetUserId();
        var result = await _repo.PostOrUnPostGrade(enrollmentId, gradingPeriodId, userId, false);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to unpost grade");
    }

    /// <summary>
    /// Creates new EnrollmentGrade entry.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentGradeDto item)
    {
        var userId = GetUserId();
        item.EncodedByUserId = (item.EncodedByUserId.Length > 0) ? item.EncodedByUserId : userId;
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EnrollmentGrade.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentGradeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EnrollmentGrade.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentGradeDto item)
    {
        var userId = GetUserId();
        item.EncodedByUserId = (item.EncodedByUserId.Length > 0) ? item.EncodedByUserId : userId;
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentGrade entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
