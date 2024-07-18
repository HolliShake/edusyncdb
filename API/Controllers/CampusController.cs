
using APPLICATION.Dto.Campus;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CampusController : GenericController<Campus, ICampusService, CampusDto, GetCampusDto>
{
    public CampusController(IMapper mapper, ICampusService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all campus by agency id.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    [HttpGet("Agency/{agencyId:int}")]
    public async Task<ActionResult> GetCampusesByAgencyId(int agencyId)
    {
        return Ok(await _repo.GetCampusByAgendyId(agencyId));
    }

    /// <summary>
    /// Get specific data (Campus) by id.
    /// </summary>
    /// <returns>Array[Campus]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Campus entry.
    /// </summary>
    /// <returns>Campus</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CampusDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Campus.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CampusDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Campus.
    /// </summary>
    /// <returns>Campus</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CampusDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Campus entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
