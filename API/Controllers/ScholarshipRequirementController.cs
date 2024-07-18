
using APPLICATION.Dto.ScholarshipRequirement;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScholarshipRequirementController : GenericController<ScholarshipRequirement, IScholarshipRequirementService, ScholarshipRequirementDto, GetScholarshipRequirementDto>
{
    public ScholarshipRequirementController(IMapper mapper, IScholarshipRequirementService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScholarshipRequirement]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScholarshipRequirement) by id.
    /// </summary>
    /// <returns>Array[ScholarshipRequirement]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScholarshipRequirement entry.
    /// </summary>
    /// <returns>ScholarshipRequirement</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScholarshipRequirementDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ScholarshipRequirement.
    /// </summary>
    /// <returns>Array[ScholarshipRequirement]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScholarshipRequirementDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ScholarshipRequirement.
    /// </summary>
    /// <returns>ScholarshipRequirement</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScholarshipRequirementDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScholarshipRequirement entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
