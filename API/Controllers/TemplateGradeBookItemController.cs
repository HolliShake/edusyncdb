
using APPLICATION.Dto.TemplateGradeBookItem;
using APPLICATION.IService;
using APPLICATION.IService.TemplateData;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TemplateGradeBookItemController : GenericController<TemplateGradeBookItem, ITemplateGradeBookItemService, TemplateGradeBookItemDto, GetTemplateGradeBookItemDto>
{
    public TemplateGradeBookItemController(IMapper mapper, ITemplateGradeBookItemService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItem]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (TemplateGradeBookItem) by id.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItem]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new TemplateGradeBookItem entry.
    /// </summary>
    /// <returns>TemplateGradeBookItem</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(TemplateGradeBookItemDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of TemplateGradeBookItem.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItem]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<TemplateGradeBookItemDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of TemplateGradeBookItem.
    /// </summary>
    /// <returns>TemplateGradeBookItem</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, TemplateGradeBookItemDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single TemplateGradeBookItem entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
