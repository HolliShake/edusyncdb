
using APPLICATION.Dto.Agency;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AgencyController : GenericController<Agency, IAgencyService, AgencyDto, GetAgencyDto>
{
    public AgencyController(IMapper mapper, IAgencyService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (Agency) by id.
    /// </summary>
    /// <returns>Array[Agency]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Agency entry.
    /// </summary>
    /// <returns>Agency</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AgencyDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Agency.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AgencyDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Agency.
    /// </summary>
    /// <returns>Agency</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AgencyDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Agency entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
