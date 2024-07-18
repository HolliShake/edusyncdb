
using APPLICATION.Dto.ScheduleAttendance;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleAttendanceController : GenericController<ScheduleAttendance, IScheduleAttendanceService, ScheduleAttendanceDto, GetScheduleAttendanceDto>
{
    public ScheduleAttendanceController(IMapper mapper, IScheduleAttendanceService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
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
    /// Creates multiple instance of ScheduleAttendance.
    /// </summary>
    /// <returns>Array[ScheduleAttendance]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleAttendanceDto> items)
    {
        return await GenericCreateAll(items);
    }
    
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
