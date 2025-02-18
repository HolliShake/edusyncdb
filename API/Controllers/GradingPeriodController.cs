using APPLICATION.Dto.GradingPeriod;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradingPeriodController : GenericController<GradingPeriod, IGradingPeriodService, GradingPeriodDto, GetGradingPeriodDto>
{
    public GradingPeriodController(IMapper mapper, IGradingPeriodService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradingPeriod]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all data by collegeId.
    /// </summary>
    /// <param name="collegeId"></param>
    /// <returns>Array[GradingPeriod]</returns>
    [HttpGet("College/{collegeId:int}")]
    public async Task<ActionResult> GetGradingPeriodByCollegeIdAction(int collegeId)
    {
        return Ok(await _repo.GetGradingPeriodByCollegeId(collegeId));
    }
    
    /// <summary>
    /// Get specific data (GradingPeriod) by id.
    /// </summary>
    /// <returns>Array[GradingPeriod]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradingPeriod entry.
    /// </summary>
    /// <returns>GradingPeriod</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradingPeriodDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradingPeriod.
    /// </summary>
    /// <returns>Array[GradingPeriod]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradingPeriodDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradingPeriod.
    /// </summary>
    /// <returns>GradingPeriod</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradingPeriodDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradingPeriod entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
