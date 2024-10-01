
using APPLICATION.Dto.AdmissionApplicantFamilyDetails;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AdmissionApplicantParentDetailsController : GenericController<AdmissionApplicantFamilyDetails, IAdmissionApplicantFamilyDetailsService, AdmissionApplicantParentDetailsDto, GetAdmissionApplicantParentDetailsDto>
{
    public AdmissionApplicantParentDetailsController(IMapper mapper, IAdmissionApplicantFamilyDetailsService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionApplicantFamilyDetails]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (AdmissionApplicantFamilyDetails) by id.
    /// </summary>
    /// <returns>Array[AdmissionApplicantFamilyDetails]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionApplicantFamilyDetails entry.
    /// </summary>
    /// <returns>AdmissionApplicantFamilyDetails</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionApplicantParentDetailsDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AdmissionApplicantFamilyDetails.
    /// </summary>
    /// <returns>Array[AdmissionApplicantFamilyDetails]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionApplicantParentDetailsDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AdmissionApplicantFamilyDetails.
    /// </summary>
    /// <returns>AdmissionApplicantFamilyDetails</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionApplicantParentDetailsDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionApplicantFamilyDetails entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
