
using APPLICATION.Dto.AccountGroup;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AccountGroupController : GenericController<AccountGroup, IAccountGroupService, AccountGroupDto, GetAccountGroupDto>
{
    public AccountGroupController(IMapper mapper, IAccountGroupService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AccountGroup]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (AccountGroup) by id.
    /// </summary>
    /// <returns>Array[AccountGroup]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AccountGroup entry.
    /// </summary>
    /// <returns>AccountGroup</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AccountGroupDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of AccountGroup.
    /// </summary>
    /// <returns>Array[AccountGroup]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AccountGroupDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of AccountGroup.
    /// </summary>
    /// <returns>AccountGroup</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AccountGroupDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AccountGroup entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
