
using APPLICATION.Dto.Room;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class RoomController : GenericController<Room, IRoomService, RoomDto, GetRoomDto>
{
    public RoomController(IMapper mapper, IRoomService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Room]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get Room by Building id.
    /// </summary>
    /// <returns>Array[Room]</returns>
    [HttpGet("Building/{buildingId:int}")]
    public async Task<ActionResult> GetRoomByBuildingId(int buildingId)
    {
        return Ok(await _repo.GetRoomByBuildingId(buildingId));
    }
    
    /// <summary>
    /// Get specific data (Room) by id.
    /// </summary>
    /// <returns>Array[Room]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Room entry.
    /// </summary>
    /// <returns>Room</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(RoomDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of Room.
    /// </summary>
    /// <returns>Array[Room]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<RoomDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of Room.
    /// </summary>
    /// <returns>Room</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, RoomDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Room entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
