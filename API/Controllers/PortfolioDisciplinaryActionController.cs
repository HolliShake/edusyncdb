
using APPLICATION.Dto.PortfolioDisciplinaryAction;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PortfolioDisciplinaryActionController : GenericController<PortfolioDisciplinaryAction, IPortfolioDisciplinaryActionService, PortfolioDisciplinaryActionDto, GetPortfolioDisciplinaryActionDto>
{
    public PortfolioDisciplinaryActionController(IMapper mapper, IPortfolioDisciplinaryActionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PortfolioDisciplinaryAction]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PortfolioDisciplinaryAction) by id.
    /// </summary>
    /// <returns>Array[PortfolioDisciplinaryAction]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PortfolioDisciplinaryAction entry.
    /// </summary>
    /// <returns>PortfolioDisciplinaryAction</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PortfolioDisciplinaryActionDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of PortfolioDisciplinaryAction.
    /// </summary>
    /// <returns>Array[PortfolioDisciplinaryAction]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PortfolioDisciplinaryActionDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of PortfolioDisciplinaryAction.
    /// </summary>
    /// <returns>PortfolioDisciplinaryAction</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PortfolioDisciplinaryActionDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PortfolioDisciplinaryAction entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
