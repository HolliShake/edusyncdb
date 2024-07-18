
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
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get enabled AdmissionProgramRequirement.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    [HttpGet("Enabled")]
    public async Task<ActionResult> GetEnabledAdmissionProgramRequirement()
    {
        return Ok(_mapper.Map<ICollection<GetAdmissionProgramRequirementDto>>(await _repo.GetEnabledAdmissionProgramRequirements()));
    }

    /// <summary>
    /// Get specific data (AdmissionProgramRequirement) by id.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionProgramRequirement entry.
    /// </summary>
    /// <returns>AdmissionProgramRequirement</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionProgramRequirementDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AdmissionProgramRequirement.
    /// </summary>
    /// <returns>Array[AdmissionProgramRequirement]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionProgramRequirementDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AdmissionProgramRequirement.
    /// </summary>
    /// <returns>AdmissionProgramRequirement</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionProgramRequirementDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionProgramRequirement entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
