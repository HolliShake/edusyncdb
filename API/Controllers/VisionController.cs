using APPLICATION.Dto.Vision;
using APPLICATION.IService.CoreData;
using AutoMapper;
using DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class VisionController : GenericController<Vision, IVisionService, VisionDto, GetVisionDto>
{
    public VisionController(IMapper mapper, IVisionService repo) : base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Vision]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (Vision) by id.
    /// </summary>
    /// <returns>Array[Vision]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new Vision entry.
    /// </summary>
    /// <returns>Vision</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(VisionDto item)
    {
        return await GenericCreate(item);
    }

        
    /// <summary>
    /// Updates multiple property of Vision.
    /// </summary>
    /// <returns>Vision</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, VisionDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single Vision entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
