
using APPLICATION.Dto.PortfolioSessionType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioSessionTypeController : GenericController<PortfolioSessionType, IPortfolioSessionTypeService, PortfolioSessionTypeDto, GetPortfolioSessionTypeDto>
{
    public PortfolioSessionTypeController(IMapper mapper, IPortfolioSessionTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioSessionType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioSessionType) by id.
    /// </summary>
    /// <returns>Array[PortfolioSessionType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioSessionType entry.
    /// </summary>
    /// <returns>PortfolioSessionType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioSessionTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of PortfolioSessionType.
    /// </summary>
    /// <returns>Array[PortfolioSessionType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioSessionTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of PortfolioSessionType.
    /// </summary>
    /// <returns>PortfolioSessionType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioSessionTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioSessionType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
