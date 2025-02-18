using APPLICATION.Dto.ScheduleTeacher;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.DesignationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScheduleTeacherController : GenericController<ScheduleTeacher, IScheduleTeacherService, ScheduleTeacherDto, GetScheduleTeacherDto>
{
    public ScheduleTeacherController(IMapper mapper, IScheduleTeacherService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScheduleTeacher) by id.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScheduleTeacher entry.
    /// </summary>
    /// <returns>ScheduleTeacher</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScheduleTeacherDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScheduleTeacher.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScheduleTeacherDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScheduleTeacher.
    /// </summary>
    /// <returns>ScheduleTeacher</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScheduleTeacherDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScheduleTeacher entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
