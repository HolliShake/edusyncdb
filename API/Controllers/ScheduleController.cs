
using APPLICATION.Dto.Schedule;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Dto.AcademicProgram;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleController : GenericController<Schedule, IScheduleService, ScheduleDto, GetScheduleDto>
{
    public ScheduleController(IMapper mapper, IScheduleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Schedule]</returns>
    [HttpGet("/Api/AcademicModule[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
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