
using APPLICATION.Dto.UserAccessGroupDetails;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService.SecurityData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UserAccessGroupDetailsController : GenericController<UserAccessGroupDetails, IUserAccessGroupDetailsService, UserAccessGroupDetailsDto, GetUserAccessGroupDetailsDto>
{
    public UserAccessGroupDetailsController(IMapper mapper, IUserAccessGroupDetailsService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[UserAccessGroupDetails]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (UserAccessGroupDetails) by id.
    /// </summary>
    /// <returns>Array[UserAccessGroupDetails]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Get UserAccess by user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Array[UserAccess]</returns>
    [HttpGet("user/{userId}")]
    public async Task<ActionResult> GetUserAccessById(string userId)
    {
        return Ok(await _repo.GetUserAccessByUserGuid(userId));
    }
    
    /// <summary>
    /// Creates new UserAccessGroupDetails entry.
    /// </summary>
    /// <returns>UserAccessGroupDetails</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(UserAccessGroupDetailsDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Creates new UserAccessGroupDetails entry.
    /// </summary>
    /// <returns>UserAccessGroupDetails</returns>
    [HttpPost("AccessGroupAction/multiple")]
    public async Task<ActionResult> CreateMultipleByAccessGroupAction(UserCampusDetailMultipleAccessGroupActionDto item)
    {
        var result = await _repo.CreateMultipleUserAccess(item);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to create user access");
    }

    /*
    /// <summary>
    /// Creates multiple instance of UserAccessGroupDetails.
    /// </summary>
    /// <returns>Array[UserAccessGroupDetails]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<UserAccessGroupDetailsDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of UserAccessGroupDetails.
    /// </summary>
    /// <returns>UserAccessGroupDetails</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, UserAccessGroupDetailsDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single UserAccessGroupDetails entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }

    /// <summary>
    /// Delete multple UserAccessGroupDetails entry.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost("delete/multiple")]
    public async Task<ActionResult> DeleteMultiple([FromBody] UserCampusDetailMultipleAccessGroupActionDto item)
    {
        var result = await _repo.DeleteMultipleUserAccess(item);
        return (result)
            ? NoContent()
            : BadRequest("Something went wrong!");
    }
}
