
using APPLICATION.Dto.CourseCrediting;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using APPLICATION.Jwt;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CourseCreditingController : GenericController<CourseCrediting, ICourseCreditingService, CourseCreditingDto, GetCourseCreditingDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public CourseCreditingController(IMapper mapper, IJwtAuthManager jwtAuthManager, ICourseCreditingService repo):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
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
    /// Get all data.
    /// </summary>
    /// <returns>Array[CourseCrediting]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Creates new CourseCrediting entry.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CourseCreditingDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Creates new CourseCrediting entry.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPost("create/user")]
    public async Task<ActionResult> CreateByUserAction(LoggedUserCourseCreditingDto item)
    {
        return await GenericCreate(new CourseCreditingDto
        {
            CreditedFromCourseTitle = item.CreditedFromCourseTitle,
            CreditedFromCourseCode = item.CreditedFromCourseCode,
            CreditedFromSchoolId = item.CreditedFromSchoolId,
            CreditGrades = item.CreditGrades,
            CreditUnits = item.CreditUnits,
            CreditToUserId = GetUserId(),
            Remarks = item.Remarks,
            EncodedDateTime = item.EncodedDateTime,
            CourseId = item.CourseId
        });
    }

    /// <summary>
    /// Creates new CourseCrediting application.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPost("application")]
    public async Task<ActionResult> CreateApplicationAction(CourseCreditingSelfServiceDto item)
    {
        var userId = GetUserId();
        return await GenericCreate(new CourseCreditingDto
        {
            CourseId = item.CourseId,
            CreditToUserId = userId,
            CreditUnits = item.CreditUnits,
            CreditGrades = item.CreditGrades,
            EncodedDateTime = DateTime.Now,
            CreditedFromCourseCode = item.CreditedFromCourseCode,
            CreditedFromCourseTitle = item.CreditedFromCourseTitle,
            CreditedFromSchoolId = item.CreditedFromSchoolId,
            Remarks = "",
            EvaluatedByUserId = null
        });
    }

    /*
    /// <summary>
    /// Creates multiple instance of CourseCrediting.
    /// </summary>
    /// <returns>Array[CourseCrediting]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseCreditingDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of CourseCrediting.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseCreditingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CourseCrediting entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }

    /// <summary>
    /// Approve course credit
    /// </summary>
    /// <param name="courseCreditingId"></param>
    /// <returns></returns>
    [HttpPut("Approve/{courseCreditingId:int}")]
    public async Task<ActionResult> ApproveAction(int courseCreditingId)
    {
        var result = await _repo.ApproveByUserAndId(GetUserId(), courseCreditingId);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to approve course");
    }

    /// <summary>
    /// Reject course credit
    /// </summary>
    /// <param name="courseCreditingId"></param>
    /// <returns></returns>
    [HttpPut("Reject/{courseCreditingId:int}")]
    public async Task<ActionResult> RejectAction(int courseCreditingId)
    {
        var result = await _repo.RejectByUserAndId(GetUserId(), courseCreditingId);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to reject course");
    }

    /// <summary>
    /// Return course credit
    /// </summary>
    /// <param name="courseCreditingId"></param>
    /// <returns></returns>
    [HttpPut("Return/{courseCreditingId:int}")]
    public async Task<ActionResult> ReturnAction(int courseCreditingId)
    {
        var result = await _repo.ReturnByUserAndId(GetUserId(), courseCreditingId);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to return course");
    }

    /// <summary>
    /// Revert course credit
    /// </summary>
    /// <param name="courseCreditingId"></param>
    /// <returns></returns>
    [HttpPut("Revert/{courseCreditingId:int}")]
    public async Task<ActionResult> RevertAction(int courseCreditingId)
    {
        var result = await _repo.RevertByUserAndId(GetUserId(), courseCreditingId);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to revert course");
    }
}
