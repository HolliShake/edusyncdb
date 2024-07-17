
using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (AdmissionApplicant) by id.
    /// </summary>
    /// <returns>Array[AdmissionApplicant]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionApplicant entry.
    /// </summary>
    /// <returns>AdmissionApplicant</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(AdmissionApplicantDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AdmissionApplicant.
    /// </summary>
    /// <returns>Array[AdmissionApplicant]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionApplicantDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AdmissionApplicant.
    /// </summary>
    /// <returns>AdmissionApplicant</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionApplicantDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionApplicant entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
