using APPLICATION.Dto.PortfolioIncident;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EPortfolioData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioIncidentController : GenericController<PortfolioIncident, IPortfolioIncidentService, PortfolioIncidentDto, GetPortfolioIncidentDto>
{
    public PortfolioIncidentController(IMapper mapper, IPortfolioIncidentService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioIncident]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioIncident) by id.
    /// </summary>
    /// <returns>Array[PortfolioIncident]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioIncident entry.
    /// </summary>
    /// <returns>PortfolioIncident</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioIncidentDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of PortfolioIncident.
    /// </summary>
    /// <returns>Array[PortfolioIncident]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioIncidentDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of PortfolioIncident.
    /// </summary>
    /// <returns>PortfolioIncident</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioIncidentDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioIncident entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
