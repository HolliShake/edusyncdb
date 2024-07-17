
using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get Group.
    /// </summary>
    /// <returns>Array[AccessList]</returns>
    [HttpGet("/Api/[controller]/Group/all")]
    public async Task<ActionResult> GetGroups()
    {
        return Ok(_mapper.Map<ICollection<GetAccessListDto>>(await _repo.GetGroups()));
    }

    /// <summary>
    /// Get specific data (AccessList) by id.
    /// </summary>
    /// <returns>Array[AccessList]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AccessList entry.
    /// </summary>
    /// <returns>AccessList</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(AccessListDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Updates multiple property of AccessList.
    /// </summary>
    /// <returns>AccessList</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccessListDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AccessList entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
