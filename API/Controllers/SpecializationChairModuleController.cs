using APPLICATION.IService;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using APPLICATION.IService.DesignationData;

namespace API.Controllers;

public class SpecializationChairModuleController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ISpecializationChairService _specializationChairService;

    public SpecializationChairModuleController(
        IJwtAuthManager jwtAuthManager,
        ISpecializationChairService specializationChairService
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _specializationChairService = specializationChairService;
    }

    protected string UserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

    protected int GetTrackSpecializationId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return int.Parse(principal.Item1.FindFirst(c => c.Type.Equals("TrackSpecializationId"))?.Value ?? "0");
    }

    /// <summary>
    /// Dashboard pending TrackSpecialization.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Dashboard/CourseCrediting/Pending/My")]
    public async Task<ActionResult> GetDashboardPendingData()
    {
        var userId = UserId();
        return Ok(await _specializationChairService.GetAllPendingCourseCrediting(userId, GetTrackSpecializationId()));
    }

    /// <summary>
    /// Get all submitted course crediting that requires my action.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Pending/My")]
    public async Task<ActionResult> GetPendingCourseCrediting()
    {
        var userId = UserId();
        return Ok(await _specializationChairService.GetAllPendingCourseCrediting(userId, GetTrackSpecializationId()));
    }

    /// <summary>
    /// Get all approved course crediting.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Approved/My")]
    public async Task<ActionResult> GetApprovedCourseCrediting()
    {
        var userId = UserId();
        return Ok(await _specializationChairService.GetAllApprovedCourseCrediting(userId, GetTrackSpecializationId()));
    }

    /// <summary>
    /// Get all rejected course crediting.
    /// </summary>
    /// <returns></returns>
    [HttpGet("CourseCrediting/Rejected/My")]
    public async Task<ActionResult> GetRejectedCourseCrediting()
    {
        var userId = UserId();
        return Ok(await _specializationChairService.GetAllRejectedCourseCrediting(userId, GetTrackSpecializationId()));
    }

    /// <summary>
    /// Get all curriculum wher I am the specialization chair (Curriculum Oversight).
    /// </summary>
    /// <returns></returns>
    [HttpGet("Curriculum/My")]
    public async Task<ActionResult> CurriculumAction()
    {
        return Ok(await _specializationChairService.GetAllCurriculumBySfTrackSpecialization(GetTrackSpecializationId()));
    }
}