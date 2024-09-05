
using APPLICATION.Dto.Schedule;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Dto.AcademicProgram;
using API.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using APPLICATION.Jwt;
using Microsoft.Net.Http.Headers;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleController : GenericController<Schedule, IScheduleService, ScheduleDto, GetScheduleDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public ScheduleController(IMapper mapper, IJwtAuthManager jwtAuthManager, IScheduleService repo):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all schedule that belongs to the current user.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("Scheduler/My")]
    public async Task<ActionResult> GetSchedulerSchedules()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        return Ok(await _repo.GetByCreatedByUserId(userId));
    }

    /// <summary>
    /// Get Schedule by AcademicPorgram id.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("AcademicPorgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetScheduleByAcademicPorgramId(int academicProgramId)
    {
        return Ok(await _repo.GetSchedulesByAcademicProgramId(academicProgramId));
    }

    /// <summary>
    /// Get Schedule by Cycle id.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("Cycle/{cycleId:int}")]
    public async Task<ActionResult> GetScheduleByCycleId(int cycleId)
    {
        return Ok(await _repo.GetSchedulesByCycleId(cycleId));
    }

    /// <summary>
    /// Get Schedule by Room id.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("Room/{roomId:int}")]
    public async Task<ActionResult> GetScheduleByRoomId(int roomId)
    {
        return Ok(await _repo.GetSchedulesByRoomId(roomId));
    }

    /// <summary>
    /// Get Schedule by Course id.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("Course/{courseId:int}")]
    public async Task<ActionResult> GetScheduleByCourseId(int courseId)
    {
        return Ok(await _repo.GetSchedulesByCourseId(courseId));
    }

    /// <summary>
    /// Get specific data (Schedule) by id.
    /// </summary>
    /// <returns>Array[Schedule]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Schedule entry.
    /// </summary>
    /// <returns>Schedule</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScheduleDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Schedule.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Creates initial multiple instance of Schedule.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpPost("generate/program/{academicProgramId:int}/cycle/{cycleId:int}/count/{numberOfSchedules:int}")]
    public async Task<ActionResult> GenerateSchedule(int academicProgramId, int cycleId, int numberOfSchedules)
    {
        var accessToken = HttpContext.Request.Headers.Authorization.ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(accessToken))
        {
            return Unauthorized();
        }

        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";

        List<ScheduleDto> schedules = [];
        for (int i = 0; i < numberOfSchedules; i++)
        {
            schedules.Add(new ScheduleDto
            {
                AcademicProgramId = academicProgramId,
                CycleId = cycleId,
                // CourseId = courseId,
                GeneratedSection = $"SCHEDULE - {i + 1}",
                GeneratedReference = $"CODE - {i + 1}",
            });
        }

        var items_or_null = await _repo.GenerateSchedule(userId, schedules);

        return (items_or_null != null)
            ? Ok(items_or_null)
            : BadRequest("Failed to create multiple schedules");
    }
    
    /// <summary>
    /// Updates multiple property of Schedule.
    /// </summary>
    /// <returns>Schedule</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScheduleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Schedule entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
