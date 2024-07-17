
using APPLICATION.Dto.PortfolioSessionInvolved;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioSessionInvolved) by id.
    /// </summary>
    /// <returns>Array[PortfolioSessionInvolved]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioSessionInvolved entry.
    /// </summary>
    /// <returns>PortfolioSessionInvolved</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(PortfolioSessionInvolvedDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of PortfolioSessionInvolved.
    /// </summary>
    /// <returns>Array[PortfolioSessionInvolved]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioSessionInvolvedDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of PortfolioSessionInvolved.
    /// </summary>
    /// <returns>PortfolioSessionInvolved</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioSessionInvolvedDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioSessionInvolved entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
