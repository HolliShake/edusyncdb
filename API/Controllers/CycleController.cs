
using APPLICATION.Dto.Cycle;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CycleController : GenericController<Cycle, ICycleService, CycleDto, GetCycleDto>
{
    public CycleController(IMapper mapper, ICycleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Cycle]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get Cycle by Campus id.
    /// </summary>
    /// <returns>Array[Cycle]</returns>
    [HttpGet("Campus/{campusId:int}")]
    public async Task<ActionResult> GetCycleByCampusId(int campusId)
    {
        return Ok(await _repo.GetCycleByCampusId(campusId));
    }

    /// <summary>
    /// Get specific data (Cycle) by id.
    /// </summary>
    /// <returns>Array[Cycle]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Cycle entry.
    /// </summary>
    /// <returns>Cycle</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CycleDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of Cycle.
    /// </summary>
    /// <returns>Array[Cycle]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CycleDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of Cycle.
    /// </summary>
    /// <returns>Cycle</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CycleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Cycle entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
