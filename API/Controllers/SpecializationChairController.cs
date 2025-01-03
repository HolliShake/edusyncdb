
using APPLICATION.Dto.SpecializationChair;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class SpecializationChairController : GenericController<SpecializationChair, ISpecializationChairService, SpecializationChairDto, GetSpecializationChairDto>
{
    public SpecializationChairController(IMapper mapper, ISpecializationChairService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SpecializationChair]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SpecializationChair) by id.
    /// </summary>
    /// <returns>Array[SpecializationChair]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SpecializationChair entry.
    /// </summary>
    /// <returns>SpecializationChair</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SpecializationChairDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SpecializationChair.
    /// </summary>
    /// <returns>Array[SpecializationChair]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SpecializationChairDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SpecializationChair.
    /// </summary>
    /// <returns>SpecializationChair</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SpecializationChairDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SpecializationChair entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
