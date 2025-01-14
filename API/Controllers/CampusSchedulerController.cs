
using APPLICATION.Dto.CampusScheduler;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CampusSchedulerController : GenericController<CampusScheduler, ICampusSchedulerService, CampusSchedulerDto, GetCampusSchedulerDto>
{
    public CampusSchedulerController(IMapper mapper, ICampusSchedulerService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CampusScheduler]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (CampusScheduler) by id.
    /// </summary>
    /// <returns>Array[CampusScheduler]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CampusScheduler entry.
    /// </summary>
    /// <returns>CampusScheduler</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CampusSchedulerDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of CampusScheduler.
    /// </summary>
    /// <returns>Array[CampusScheduler]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CampusSchedulerDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of CampusScheduler.
    /// </summary>
    /// <returns>CampusScheduler</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CampusSchedulerDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CampusScheduler entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
