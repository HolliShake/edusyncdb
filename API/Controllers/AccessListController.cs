using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AccessListController : GenericController<AccessList, IAccessListService, AccessListDto, GetAccessListDto>
{
    private readonly IAccessListActionService _accessListActionService;
    public AccessListController(IMapper mapper, IAccessListService repo, IAccessListActionService accessListActionRepo):base(mapper, repo)
    {
        _accessListActionService = accessListActionRepo;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AccessList]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (AccessList) by id.
    /// </summary>
    /// <returns>Array[AccessList]></returns>
    [HttpGet("AccessGroup/{accessGroupId:int}")]
    public async Task<ActionResult> GetByAccessGroup(int accessGroupId)
    {
        return Ok(await _repo.GetByAccessGroupId(accessGroupId));
    }

    /// <summary>
    /// Get specific data (AccessList) by id.
    /// </summary>
    /// <returns>Array[AccessList]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AccessList entry.
    /// </summary>
    /// <returns>AccessList</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AccessListDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Updates multiple property of AccessList.
    /// </summary>
    /// <returns>AccessList</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccessListDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AccessList entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
