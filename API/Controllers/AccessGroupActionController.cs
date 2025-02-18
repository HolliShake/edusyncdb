using APPLICATION.Dto.AccessGroupAction;
using APPLICATION.IService.SecurityData;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AccessGroupActionController : GenericController<AccessGroupAction, IAccessGroupActionService, AccessGroupActionDto, GetAccessGroupActionDto>
{
    public AccessGroupActionController(IMapper mapper, IAccessGroupActionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AccessGroupAction]</returns>
    /// <operationId>getAllAccessGroup</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (AccessGroupAction) by id.
    /// </summary>
    /// <returns>Array[AccessGroupAction]></returns>
    /// <operationId>getAccessGroupById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AccessGroupAction entry.
    /// </summary>
    /// <returns>AccessGroupAction</returns>
    /// <operationId>createAccessGroup</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AccessGroupActionDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AccessGroupAction.
    /// </summary>
    /// <returns>Array[AccessGroupAction]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AccessGroupActionDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AccessGroupAction.
    /// </summary>
    /// <returns>AccessGroupAction</returns>
    /// <operationId>updateAccessGroup</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccessGroupActionDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AccessGroupAction entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAccessGroup</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
