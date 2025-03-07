using APPLICATION.Dto.ScheduleMerge;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.SchedulingData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleMergeController : GenericController<ScheduleMerge, IScheduleMergeService, ScheduleMergeDto, GetScheduleMergeDto>
{
    public ScheduleMergeController(IMapper mapper, IScheduleMergeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScheduleMerge]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScheduleMerge) by id.
    /// </summary>
    /// <returns>Array[ScheduleMerge]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScheduleMerge entry.
    /// </summary>
    /// <returns>ScheduleMerge</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScheduleMergeDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScheduleMerge.
    /// </summary>
    /// <returns>Array[ScheduleMerge]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleMergeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScheduleMerge.
    /// </summary>
    /// <returns>ScheduleMerge</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScheduleMergeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScheduleMerge entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
