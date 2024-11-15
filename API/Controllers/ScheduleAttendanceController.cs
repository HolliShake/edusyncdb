
using APPLICATION.Dto.ScheduleAttendance;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using INFRASTRUCTURE;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using APPLICATION.Jwt;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleAttendanceController : GenericController<ScheduleAttendance, IScheduleAttendanceService, ScheduleAttendanceDto, GetScheduleAttendanceDto>
{
    protected readonly IJwtAuthManager _jwtAuthManager;
    public ScheduleAttendanceController(
        IJwtAuthManager jwtAuthManager,
        IMapper mapper, 
        IScheduleAttendanceService repo

    ):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get current user id.
    /// </summary>
    /// <returns></returns>
    protected string GetUserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScheduleAttendance]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScheduleAttendance) by id.
    /// </summary>
    /// <returns>Array[ScheduleAttendance]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScheduleAttendance entry.
    /// </summary>
    /// <returns>ScheduleAttendance</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScheduleAttendanceDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Submit attendance.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <param name="isTimeIn"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost("submit/Schedule/{scheduleId:int}/IsTimeIn/{isTimeIn:bool}/My")]
    public async Task<ActionResult> SubmitAttendanceinmt(int scheduleId, bool isTimeIn, IFormFile file)
    {
        var userId = GetUserId();
        var result = await _repo.SubmitAttendance(userId, isTimeIn, scheduleId, file);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to submit attendance");
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScheduleAttendance.
    /// </summary>
    /// <returns>Array[ScheduleAttendance]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleAttendanceDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScheduleAttendance.
    /// </summary>
    /// <returns>ScheduleAttendance</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScheduleAttendanceDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScheduleAttendance entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
