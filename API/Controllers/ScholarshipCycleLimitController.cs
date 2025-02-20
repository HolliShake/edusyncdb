
using APPLICATION.Dto.ScholarshipCycleLimit;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ScholarshipData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScholarshipCycleLimitController : GenericController<ScholarshipCycleLimit, IScholarshipCycleLimitService, ScholarshipCycleLimitDto, GetScholarshipCycleLimitDto>
{
    public ScholarshipCycleLimitController(IMapper mapper, IScholarshipCycleLimitService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScholarshipCycleLimit]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScholarshipCycleLimit) by id.
    /// </summary>
    /// <returns>Array[ScholarshipCycleLimit]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScholarshipCycleLimit entry.
    /// </summary>
    /// <returns>ScholarshipCycleLimit</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScholarshipCycleLimitDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScholarshipCycleLimit.
    /// </summary>
    /// <returns>Array[ScholarshipCycleLimit]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScholarshipCycleLimitDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScholarshipCycleLimit.
    /// </summary>
    /// <returns>ScholarshipCycleLimit</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScholarshipCycleLimitDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScholarshipCycleLimit entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
