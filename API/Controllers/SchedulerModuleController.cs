using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using APPLICATION.IService.CoreData;
using APPLICATION.IService.DesignationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class SchedulerModuleController : ControllerBase {
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ICampusSchedulerService _repo;
    private readonly ICycleService _cycleService;

    public SchedulerModuleController(
        IJwtAuthManager jwtAuthManager,
        ICampusSchedulerService repo,
        ICycleService cycleService
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _repo = repo;
        _cycleService = cycleService;
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
    /// Get current scheduler user
    /// </summary>
    /// <returns></returns>
    protected int GetCampusId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("SchedulerCampusId"))?.Value ?? "0");
    }
    
    /// <summary>
    /// Get all cycles in my campus id where I am the scheduler.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Cycles/My")]
    public async Task<ActionResult> GetCycles()
    {
        var campusId = GetCampusId();
        return Ok(await _cycleService.GetCycleByCampusId(campusId));
    }
    
    /// <summary>
    /// Get all buildings including Schedule per room
    /// </summary>
    /// <returns></returns>
    [HttpGet("Buildings/Schedules/My")]
    public async Task<ActionResult> GetBuildingRoomSchedules()
    {
        var campusId = GetCampusId();
        return Ok(await _repo.GetBuildingWithinRoomsSchedulesByUserAndCampusId(GetUserId(), campusId));
    }

    /// <summary>
    /// Get all schedules for a specific campus.
    /// </summary>
    /// <returns></returns>
    [HttpGet("MergedSchedules/Campus/My")]
    public async Task<IActionResult> GetMergedSchedules()
    {
        var campusId = GetCampusId();
        return Ok(await _repo.GetMergedSchedulesBySchedulerUserAndCampusId(GetUserId(), campusId));
    }

    /// <summary>
    /// Get all schedules for a specific campus.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ClassSchedules/Campus/My")]
    public async Task<IActionResult> GetClassScheduleByCampus()
    {
        var campusId = GetCampusId();
        return Ok(await _repo.GetClassScheduleBySchedulerUserAndCampusId(GetUserId(), campusId));
    }

    /// <summary>
    /// Get all examination schedules for a specific campus.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ExamSchedules/Campus/My")]
    public async Task<IActionResult> GetExaminationScheduleByCampus()
    {
        var campusId = GetCampusId();
        return Ok(await _repo.GetExamScheduleBySchedulerUserAndCampusId(GetUserId(), campusId));
    }
}
