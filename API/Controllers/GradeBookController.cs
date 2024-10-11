
using APPLICATION.Dto.GradeBook;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookController : GenericController<GradeBook, IGradeBookService, GradeBookDto, GetGradeBookDto>
{
    public GradeBookController(IMapper mapper, IGradeBookService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBook]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get gradebook by schedule id.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <returns>GradeBook?</returns>
    [HttpGet("Schedule/{scheduleId:int}")]
    public async Task<ActionResult> GetGradeBookByScheduleId(int scheduleId)
    {
        var result = await _repo.GetGradeBookByScheduleId(scheduleId);

        return (result != null)
            ? Ok(result)
            : NoContent();
    }

    /// <summary>
    /// Get specific data (GradeBook) by id.
    /// </summary>
    /// <returns>Array[GradeBook]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Generate GradeBook from Template.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <param name="templateId"></param>
    /// <returns>Object</returns>
    [HttpPost("Generate/Schedule/{scheduleId:int}/Template/{templateId:int}")]
    public async Task<ActionResult> GenerateGradeBookFromTemplate(int scheduleId, int templateId)
    {
        var result = await _repo.GenerateGradeBookFromTemplate(scheduleId, templateId);

        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to generate GradeBook from Template");
    }
    
    /// <summary>
    /// Creates new GradeBook entry.
    /// </summary>
    /// <returns>GradeBook</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradeBook.
    /// </summary>
    /// <returns>Array[GradeBook]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradeBook.
    /// </summary>
    /// <returns>GradeBook</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeBook entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
