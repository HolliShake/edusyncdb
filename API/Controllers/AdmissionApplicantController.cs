using APPLICATION.Dto.AdmissionApplicant;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.AdmissionData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionApplicantController : GenericController<AdmissionApplicant, IAdmissionApplicantService, AdmissionApplicantDto, GetAdmissionApplicantDto>
{
    public AdmissionApplicantController(IMapper mapper, IAdmissionApplicantService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionApplicant]</returns>
    /// <operationId>getAllAdmissionApplicant</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (AdmissionApplicant) by id.
    /// </summary>
    /// <returns>Array[AdmissionApplicant]></returns>
    /// <operationId>getAdmissionApplicationById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AdmissionApplicant entry.
    /// </summary>
    /// <returns>AdmissionApplicant</returns>
    /// <operationId>createAdmissionApplicant</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionApplicantDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Apply Admission.
    /// </summary>
    /// <returns>AdmissionApplicant</returns>
    /// <operationId>applyAdmissionApplicant</operationId>
    [HttpPost("apply")]
    public async Task<ActionResult> CreateGroupApplyAction(AdmissionApplicantGroupedDto group)
    {
        var result = await _repo.ApplyApplication(group);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to create");
    }

    /*
    /// <summary>
    /// Creates multiple instance of AdmissionApplicant.
    /// </summary>
    /// <returns>Array[AdmissionApplicant]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionApplicantDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AdmissionApplicant.
    /// </summary>
    /// <returns>AdmissionApplicant</returns>
    /// <operationId>updateAdmissionApplicant</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionApplicantDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AdmissionApplicant entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAdmissionApplicant</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
