using API.Attributes;
using APPLICATION.Dto.AccessGroup;
using APPLICATION.Dto.AccessGroup;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AccessGroupController : GenericController<AccessGroup, IAccessGroupService, AccessGroupDto, GetAccessGroupDto>
{
    public AccessGroupController(IMapper mapper, IAccessGroupService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AccessGroup]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (AccessGroup) by id.
    /// </summary>
    /// <returns>Array[AccessGroup]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AccessGroup entry.
    /// </summary>
    /// <returns>AccessGroup</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AccessGroupDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AccessGroup.
    /// </summary>
    /// <returns>Array[AccessGroup]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AccessGroupDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AccessGroup.
    /// </summary>
    /// <returns>AccessGroup</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccessGroupDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AccessGroup entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
