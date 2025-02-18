using APPLICATION.Dto.GradeBookItem;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.GradeBookData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookItemController : GenericController<GradeBookItem, IGradeBookItemService, GradeBookItemDto, GetGradeBookItemDto>
{
    public GradeBookItemController(IMapper mapper, IGradeBookItemService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBookItem]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GradeBookItem) by id.
    /// </summary>
    /// <returns>Array[GradeBookItem]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeBookItem entry.
    /// </summary>
    /// <returns>GradeBookItem</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookItemDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradeBookItem.
    /// </summary>
    /// <returns>Array[GradeBookItem]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookItemDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradeBookItem.
    /// </summary>
    /// <returns>GradeBookItem</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookItemDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeBookItem entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
