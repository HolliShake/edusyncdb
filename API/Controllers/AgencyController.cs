
using APPLICATION.Dto.Agency;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;
using APPLICATION.Jwt;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AgencyController : GenericController<Agency, IAgencyService, AgencyDto, GetAgencyDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public AgencyController(IMapper mapper, IAgencyService repo, IJwtAuthManager jwtAuthManager) :base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    /// <operationId>getAllAgency</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (Agency) by id.
    /// </summary>
    /// <returns>Array[Agency]></returns>
    /// <operationId>getAgencyById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new Agency entry.
    /// </summary>
    /// <returns>Agency</returns>
    /// <operationId>createAgency</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AgencyDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Creates multiple instance of Agency.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    /// <operationId>insertAgency</operationId>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AgencyDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Updates multiple property of Agency.
    /// </summary>
    /// <returns>Agency</returns>
    /// <operationId>updateAgency</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AgencyDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single Agency entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAgency</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
