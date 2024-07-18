
using APPLICATION.Dto.PortfolioIncidentType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioIncidentTypeController : GenericController<PortfolioIncidentType, IPortfolioIncidentTypeService, PortfolioIncidentTypeDto, GetPortfolioIncidentTypeDto>
{
    public PortfolioIncidentTypeController(IMapper mapper, IPortfolioIncidentTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioIncidentType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioIncidentType) by id.
    /// </summary>
    /// <returns>Array[PortfolioIncidentType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioIncidentType entry.
    /// </summary>
    /// <returns>PortfolioIncidentType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioIncidentTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of PortfolioIncidentType.
    /// </summary>
    /// <returns>Array[PortfolioIncidentType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioIncidentTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of PortfolioIncidentType.
    /// </summary>
    /// <returns>PortfolioIncidentType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioIncidentTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioIncidentType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
