
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using APPLICATION.Jwt;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UserCampusDetailsController : GenericController<UserCampusDetails, IUserCampusDetailsService, UserCampusDetailsDto, GetUserCampusDetailsDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public UserCampusDetailsController(IMapper mapper, IJwtAuthManager authManager, IUserCampusDetailsService repo):base(mapper, repo)
    {
        _jwtAuthManager = authManager;
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
    /// Get All campus that I have access.
    /// </summary>
    /// <returns>Array[UserCampusDetails]</returns>
    [HttpGet("MyCampusAccess")]
    public async Task<ActionResult> GetMyAction()
    {
        var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        return Ok(await _repo.GetAllCampusByUserId(userId));
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
    
    /*
    /// <summary>
    /// Creates multiple instance of UserCampusDetails.
    /// </summary>
    /// <returns>Array[UserCampusDetails]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<UserCampusDetailsDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
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
