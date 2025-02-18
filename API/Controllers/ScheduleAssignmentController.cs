using APPLICATION.Dto.ScheduleAssignment;
using APPLICATION.IService.SchedulingData;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class ScheduleAssignmentController : GenericController<ScheduleAssignment, IScheduleAssignmentService, ScheduleAssignmentDto, GetScheduleAssignmentDto>
{
    public ScheduleAssignmentController(IMapper mapper, IScheduleAssignmentService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScheduleAssignment]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScheduleAssignment) by id.
    /// </summary>
    /// <returns>Array[ScheduleAssignment]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new ScheduleAssignment by merge code.
    /// </summary>
    /// <returns>ScheduleAssignment</returns>
    [HttpPost("SchedulerModule/create/{mergeCode}")]
    public async Task<ActionResult> CreateAction(string mergeCode, ScheduleAssignmentMergeCodeDto item) {
        return Ok(await _repo.CreateScheduleAssignmentByMergeCode(mergeCode, item));
    }

    /// <summary>
    /// Creates new ScheduleAssignment entry.
    /// </summary>
    /// <returns>ScheduleAssignment</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScheduleAssignmentDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ScheduleAssignment.
    /// </summary>
    /// <returns>Array[ScheduleAssignment]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleAssignmentDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ScheduleAssignment.
    /// </summary>
    /// <returns>ScheduleAssignment</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScheduleAssignmentDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScheduleAssignment entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }

    /// <summary>
    /// Get all data by merge code.
    /// </summary>
    /// <param name="mergeCode"></param>
    /// <returns></returns>
    [HttpGet("SchedulerModule/delete/{mergeCode}")]
    public async Task<ActionResult> DeleteByMergeCodeAction(string mergeCode)
    {
        return Ok(await _repo.DeleteScheduleAssignmentByMergeCode(mergeCode));
    }
}
