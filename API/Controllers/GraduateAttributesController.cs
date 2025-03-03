
using APPLICATION.Dto.GraduateAttributes;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class GraduateAttributesController : GenericController<GraduateAttributes, IGraduateAttributesService, GraduateAttributesDto, GetGraduateAttributesDto>
{
    public GraduateAttributesController(IMapper mapper, IGraduateAttributesService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GraduateAttributes]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GraduateAttributes) by id.
    /// </summary>
    /// <returns>Array[GraduateAttributes]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GraduateAttributes entry.
    /// </summary>
    /// <returns>GraduateAttributes</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GraduateAttributesDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of GraduateAttributes.
    /// </summary>
    /// <returns>Array[GraduateAttributes]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GraduateAttributesDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of GraduateAttributes.
    /// </summary>
    /// <returns>GraduateAttributes</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GraduateAttributesDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GraduateAttributes entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
