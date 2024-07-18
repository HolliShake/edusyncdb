
using APPLICATION.Dto.AccessListAction;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AccessListActionController : GenericController<AccessListAction, IAccessListActionService, AccessListActionDto, GetAccessListActionDto>
{
    public AccessListActionController(IMapper mapper, IAccessListActionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AccessListAction]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AccessListAction by AccessList id.
    /// </summary>
    /// <returns>Array[AccessListAction]</returns>
    [HttpGet("AccessList/{accessListId:int}")]
    public async Task<ActionResult> GetActionAccessListActionByAccessListId(int accessListId)
    {
        return Ok(_mapper.Map<ICollection<GetAccessListActionDto>>(await _repo.GetAccessListActionsByAccessListId(accessListId)));
    }

    /// <summary>
    /// Get specific data (AccessListAction) by id.
    /// </summary>
    /// <returns>Array[AccessListAction]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AccessListAction entry.
    /// </summary>
    /// <returns>AccessListAction</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AccessListActionDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AccessListAction.
    /// </summary>
    /// <returns>Array[AccessListAction]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AccessListActionDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AccessListAction.
    /// </summary>
    /// <returns>AccessListAction</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccessListActionDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AccessListAction entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
