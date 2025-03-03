using APPLICATION.Dto.Mission;
using APPLICATION.Dto.Mission;
using APPLICATION.IService.CoreData;
using AutoMapper;
using DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MissionController : GenericController<Mission, IMissionService, MissionDto, GetMissionDto>
{
    public MissionController(IMapper mapper, IMissionService repo): base(mapper, repo)
    {
        
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Mission]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (Mission) by id.
    /// </summary>
    /// <returns>Array[Mission]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new Mission entry.
    /// </summary>
    /// <returns>Mission</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(MissionDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of Mission.
    /// </summary>
    /// <returns>Array[Mission]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<MissionDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of Mission.
    /// </summary>
    /// <returns>Mission</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, MissionDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single Mission entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}