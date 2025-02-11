
using APPLICATION.Dto.AdmissionScore;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionScoreController : GenericController<AdmissionScore, IAdmissionScoreService, AdmissionScoreDto, GetAdmissionScoreDto>
{
    public AdmissionScoreController(IMapper mapper, IAdmissionScoreService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionScore]</returns>
    /// <operationId>getAllAdmissionScore</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AdmissionScore by AdmissionEvaluationSchedule id.
    /// </summary>
    /// <returns>Array[AdmissionScore]</returns>
    /// <operationId>getAdmissionScoreByAdmissionEvaluationScheduleId</operationId>
    [HttpGet("AdmissionEvaluationSchedule/{admissionEvaluationScheduleId:int}")]
    public async Task<ActionResult> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId)
    {
        return Ok(await _repo.GetAdmissionScoreByAdmissionEvaluationScheduleId(admissionEvaluationScheduleId));
    }

    /// <summary>
    /// Get AdmissionScore by AdmissionProgramRequirement id.
    /// </summary>
    /// <returns>Array[AdmissionScore]</returns>
    /// <operationId>getAdmissionScoreByAdmissionProgramRequirementId</operationId>
    [HttpGet("AdmissionProgramRequirement/{admissionProgramRequirementId:int}")]
    public async Task<ActionResult> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId)
    {
        return Ok(await _repo.GetAdmissionScoreByAdmissionProgramRequirementId(admissionProgramRequirementId));
    }

    /// <summary>
    /// Get AdmissionScore by AdmissionApplicant id.
    /// </summary>
    /// <returns>Array[AdmissionScore]</returns>
    /// <operationId>getAdmissionScoreByApllicationApplicantId</operationId>
    [HttpGet("AdmissionApplicant/{admissionApplicantId:int}")]
    public async Task<ActionResult> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId)
    {
        return Ok(await _repo.GetAdmissionScoreByAdmissionApplicantId(admissionApplicantId));
    }

    /// <summary>
    /// Get specific data (AdmissionScore) by id.
    /// </summary>
    /// <returns>Array[AdmissionScore]></returns>
    /// <operationId>getAdmissionScoreById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AdmissionScore entry.
    /// </summary>
    /// <returns>AdmissionScore</returns>
    /// <operationId>createAdmissionScore</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionScoreDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AdmissionScore.
    /// </summary>
    /// <returns>Array[AdmissionScore]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionScoreDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AdmissionScore.
    /// </summary>
    /// <returns>AdmissionScore</returns>
    /// <operationId>updateAdmissionScore</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionScoreDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AdmissionScore entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAdmissionScore</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
