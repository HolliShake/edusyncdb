
using APPLICATION.Dto.TemplateGradeBook;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TemplateGradeBookController : GenericController<TemplateGradeBook, ITemplateGradeBookService, TemplateGradeBookDto, GetTemplateGradeBookDto>
{
    public TemplateGradeBookController(IMapper mapper, ITemplateGradeBookService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[TemplateGradeBook]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all TemplateGradeBook data as structured.
    /// </summary>
    /// <returns>Array[object]</returns>
    [HttpGet("all/structured")]
    public async Task<ActionResult> GetAllStructured()
    {
        return Ok(await _repo.GetAllAsStructuredAsync());
    }
    
    /// <summary>
    /// Get specific data (TemplateGradeBook) by id.
    /// </summary>
    /// <returns>Array[TemplateGradeBook]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Create template by group
    /// </summary>
    /// <param name="template"></param>
    /// <returns>object</returns>
    [HttpPost("template/create")]
    public async Task<ActionResult> CreateGroupAction(TemplateGradeBookGroupDto template)
    {
        var result = await _repo.TemplateGroupCreate(template);

        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to create template");
    }
    
    /// <summary>
    /// Creates new TemplateGradeBook entry.
    /// </summary>
    /// <returns>TemplateGradeBook</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(TemplateGradeBookDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of TemplateGradeBook.
    /// </summary>
    /// <returns>Array[TemplateGradeBook]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<TemplateGradeBookDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of TemplateGradeBook.
    /// </summary>
    /// <returns>TemplateGradeBook</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, TemplateGradeBookDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single TemplateGradeBook entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
