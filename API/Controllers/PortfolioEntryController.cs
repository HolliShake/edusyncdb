
using APPLICATION.Dto.PortfolioEntry;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioEntryController : GenericController<PortfolioEntry, IPortfolioEntryService, PortfolioEntryDto, GetPortfolioEntryDto>
{
    public PortfolioEntryController(IMapper mapper, IPortfolioEntryService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioEntry]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioEntry) by id.
    /// </summary>
    /// <returns>Array[PortfolioEntry]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioEntry entry.
    /// </summary>
    /// <returns>PortfolioEntry</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioEntryDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of PortfolioEntry.
    /// </summary>
    /// <returns>Array[PortfolioEntry]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioEntryDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of PortfolioEntry.
    /// </summary>
    /// <returns>PortfolioEntry</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioEntryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioEntry entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
