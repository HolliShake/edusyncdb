
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UserCampusDetailsController : GenericController<UserCampusDetails, IUserCampusDetailsService, UserCampusDetailsDto, GetUserCampusDetailsDto>
{
    public UserCampusDetailsController(IMapper mapper, IUserCampusDetailsService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[UserCampusDetails]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (UserCampusDetails) by id.
    /// </summary>
    /// <returns>Array[UserCampusDetails]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new UserCampusDetails entry.
    /// </summary>
    /// <returns>UserCampusDetails</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(UserCampusDetailsDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of UserCampusDetails.
    /// </summary>
    /// <returns>Array[UserCampusDetails]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<UserCampusDetailsDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of UserCampusDetails.
    /// </summary>
    /// <returns>UserCampusDetails</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, UserCampusDetailsDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single UserCampusDetails entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
