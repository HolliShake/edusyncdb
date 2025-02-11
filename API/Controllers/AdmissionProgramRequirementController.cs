using APPLICATION.Dto.AdmissionProgramRequirement;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionProgramRequirementController : GenericController<AdmissionProgramRequirement, IAdmissionProgramRequirementService, AdmissionProgramRequirementDto, GetAdmissionProgramRequirementDto>
{
    public AdmissionProgramRequirementController(IMapper mapper, IAdmissionProgramRequirementService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    /// <operationId>getAllAdmissionProgramRequirement</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get enabled AdmissionProgramRequirement.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    /// <operationId>getAllEnabledAdmissionProgramRequirement</operationId>
    [HttpGet("Enabled")]
    public async Task<ActionResult> GetEnabledAdmissionProgramRequirement()
    {
        return Ok(await _repo.GetEnabledAdmissionProgramRequirements());
    }

    /*
    /// <summary>
    /// Get all AdmissionProgramRequirement Grouped by AdmissionRequirementId.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    [HttpGet("Grouped/all")]
    public async Task<ActionResult> GetAllGroupedAction()
    {
        return Ok(await _repo.GetAllGroupedByRequirementAsync());
    }
    */

    /// <summary>
    /// Get specific data (AdmissionProgramRequirement) by id.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]></returns>
    /// <operationId>getAdmissionProgramRequirementById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AdmissionProgramRequirement entry.
    /// </summary>
    /// <returns>AdmissionProgramRequirement</returns>
    /// <operationId>createAdmissionProgramRequirement</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionProgramRequirementDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Creates multiple instance of AdmissionProgramRequirement.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    /// <operationId>insertAdmissionProgramRequirement</operationId>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionProgramRequirementDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Creates multiple instance of AdmissionProgramRequirement.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    /// <operationId>createMultipleProgramRequirement</operationId>
    [HttpPost("Requirement/multiple")]
    public async Task<ActionResult> CreateManyByRequirementIdArray(AdmissionProgramRequirementMultipleDto item)
    {
        var result = await _repo.CreateMultipleAdmissionProgramRequirement(item);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to create admission program requirement");
    }

    /// <summary>
    /// Updates multiple property of AdmissionProgramRequirement.
    /// </summary>
    /// <returns>AdmissionProgramRequirement</returns>
    /// <operationId>updateAdmissionProgramRequirement</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionProgramRequirementDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AdmissionProgramRequirement entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAdmissionProgramRequirement</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
