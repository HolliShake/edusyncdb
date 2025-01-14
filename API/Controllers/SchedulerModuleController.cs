using APPLICATION.IService;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchedulerModuleController : ControllerBase {
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ICampusSchedulerService _repo;

    public SchedulerModuleController(
        IJwtAuthManager jwtAuthManager,
        ICampusSchedulerService repo
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _repo = repo;
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
    /// Get All campuses that I am assigned to as a scheduler.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Campuses/My")]
    public async Task<IActionResult> GetMyCampusesAction()
    {
        return Ok(await _repo.GetCampusesByUserId(GetUserId()));
    }

    /// <summary>
    /// Get all schedules for a specific campus.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns></returns>
    [HttpGet("MergedSchedules/Campus/{campusId:int}")]
    public async Task<IActionResult> GetMergedSchedules(int campusId)
    {
        return Ok(await _repo.GetMergedSchedulesBySchedulerUserAndCampusId(GetUserId(), campusId));
    }

    /// <summary>
    /// Get all schedules for a specific campus.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns></returns>
    [HttpGet("ClassSchedules/Campus/{campusId:int}")]
    public async Task<IActionResult> GetClassScheduleByCampus(int campusId)
    {
        return Ok(await _repo.GetClassScheduleBySchedulerUserAndCampusId(GetUserId(), campusId));
    }

    /// <summary>
    /// Get all examination schedules for a specific campus.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns></returns>
    [HttpGet("ExamSchedules/Campus/{campusId:int}")]
    public async Task<IActionResult> GetExaminationScheduleByCampus(int campusId)
    {
        return Ok(await _repo.GetExamScheduleBySchedulerUserAndCampusId(GetUserId(), campusId));
    }
}
