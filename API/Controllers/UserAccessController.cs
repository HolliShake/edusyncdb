
using APPLICATION.Dto.UserAccess;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class UserAccessController : GenericController<UserAccess, IUserAccessService, UserAccessDto, GetUserAccessDto>
{
    public UserAccessController(IMapper mapper, IUserAccessService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[UserAccess]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (UserAccess) by id.
    /// </summary>
    /// <returns>Array[UserAccess]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new UserAccess entry.
    /// </summary>
    /// <returns>UserAccess</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(UserAccessDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of UserAccess.
    /// </summary>
    /// <returns>Array[UserAccess]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<UserAccessDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Updates multiple property of UserAccess.
    /// mode:
    ///      0 := CREATE
    ///      1 := UPATE
    ///      2 := DELETE
    /// </summary>
    /// <returns>UserAccess</returns>
    [HttpPost("update/multiple")]
    public async Task<ActionResult> UpdateAccess(List<UpdateUserAccessDto> items)
    {
        var result = await _repo.UpdateUserAccess(items);
        return (result != null)
            ? Ok(result)
            : BadRequest();
    }
    
    /// <summary>
    /// Updates multiple property of UserAccess.
    /// </summary>
    /// <returns>UserAccess</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, UserAccessDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single UserAccess entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
