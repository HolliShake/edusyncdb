
using APPLICATION.Dto.PortfolioSessionInvolved;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioSessionInvolvedController : GenericController<PortfolioSessionInvolved, IPortfolioSessionInvolvedService, PortfolioSessionInvolvedDto, GetPortfolioSessionInvolvedDto>
{
    public PortfolioSessionInvolvedController(IMapper mapper, IPortfolioSessionInvolvedService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioSessionInvolved]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioSessionInvolved) by id.
    /// </summary>
    /// <returns>Array[PortfolioSessionInvolved]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioSessionInvolved entry.
    /// </summary>
    /// <returns>PortfolioSessionInvolved</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioSessionInvolvedDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of PortfolioSessionInvolved.
    /// </summary>
    /// <returns>Array[PortfolioSessionInvolved]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioSessionInvolvedDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of PortfolioSessionInvolved.
    /// </summary>
    /// <returns>PortfolioSessionInvolved</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioSessionInvolvedDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioSessionInvolved entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
