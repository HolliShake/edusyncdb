
using API.Attributes;
using APPLICATION.Dto.User;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class UserController : GenericController<User, IUserService, UserDto, GetUserDto>
{
    public UserController(IMapper mapper, IUserService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[User]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[User]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunkAction(int size)
    {
        return await GenericGetByChunk(size);
    }

    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data with user access.
    /// </summary>
    /// <returns>Array[User]</returns>
    [HttpGet("chunk/with-useraccess/{size:int}")]
    public async Task<ActionResult> GetByChunkWithUserAccessAction(int size)
    {
        return Ok(await _repo.GetLimitedUserWithAccess(size));
    }

    /// <summary>
    /// Search user by name.
    /// </summary>
    /// <returns>Array[User]</returns>
    [HttpPost("search")]
    public async Task<ActionResult> SearchUser([FromBody] string searchKey)
    {
        return Ok(await _repo.SearchUserByName(searchKey));
    }

    /// <summary>
    /// Get specific data (User) by id.
    /// </summary>
    /// <returns>Array[User]></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAction(string id)
    {
        var user = await _repo.GetUserId(id);
        return (user != null)
            ? Ok(_mapper.Map<GetUserDto>(user))
            : NotFound();
    }

    /// <summary>
    /// Creates new User entry.
    /// </summary>
    /// <returns>User</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(UserDto item)
    {
        return await GenericCreate(item);
    }


    /// <summary>
    /// Creates multiple instance of User.
    /// </summary>
    /// <returns>Array[User]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<UserDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Updates multiple property of User.
    /// </summary>
    /// <returns>User</returns>
    [HttpPut("update/{id}")]
    public async Task<ActionResult> UpdateAction(string id, UserDto item)
    {
        var record = await _repo.GetUserId(id);

        if (record == null)
        {
            return NotFound();
        }

        var model = _mapper.Map(item, record);

        var result = /**/
            await _repo.UpdateSync(model);

        return (result)
            ? Ok(_mapper.Map<GetUserOnlyDto>(model))
            : BadRequest("Something went wrong!");
    }

    /// <summary>
    /// Deletes single User entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteAction(string id)
    {
        var record = await _repo.GetUserId(id);

        if (record == null)
        {
            return NotFound();
        }

        var result = /**/
            await _repo.DeleteSync(record);

        return (result)
            ? NoContent()
            : BadRequest("Something went wrong!");
    }
}