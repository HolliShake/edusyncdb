using APPLICATION.Dto.PortfolioType;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EPortfolioData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioTypeController : GenericController<PortfolioType, IPortfolioTypeService, PortfolioTypeDto, GetPortfolioTypeDto>
{
    public PortfolioTypeController(IMapper mapper, IPortfolioTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioType) by id.
    /// </summary>
    /// <returns>Array[PortfolioType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioType entry.
    /// </summary>
    /// <returns>PortfolioType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of PortfolioType.
    /// </summary>
    /// <returns>Array[PortfolioType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of PortfolioType.
    /// </summary>
    /// <returns>PortfolioType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
