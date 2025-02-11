
using APPLICATION.Dto.AdmissionApplication;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionApplicationController : GenericController<AdmissionApplication, IAdmissionApplicationService, AdmissionApplicationDto, GetAdmissionApplicationDto>
{
    public AdmissionApplicationController(IMapper mapper, IAdmissionApplicationService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionApplication]</returns>
    /// <operationId>getAllAdmissionApplication</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[AdmissionApplication]</returns>
    /// <operationId>getAdmissionApplicationByChunk</operationId>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }

    /// <summary>
    /// Get AdmissionApplication by AdmissionSchedule id.
    /// </summary>
    /// <returns>Array[AdmissionApplication]</returns>
    /// <operationId>getAdmissionApplicationByScheduleId</operationId>
    [HttpGet("AdmissionSchedule/{admissionScheduleId:int}")]
    public async Task<ActionResult> GetAdmissionApplicationByAdmissionScheduleId(int admissionScheduleId)
    {
        return Ok(await _repo.GetAdmissionApplicationsByAdmissionScheduleId(admissionScheduleId));
    }

    /// <summary>
    /// Get specific data (AdmissionApplication) by id.
    /// </summary>
    /// <returns>Array[AdmissionApplication]></returns>
    /// <operationId>getAdmissionApplicationById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AdmissionApplication entry.
    /// </summary>
    /// <returns>AdmissionApplication</returns>
    /// <operationId>createAdmissionApplication</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionApplicationDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AdmissionApplication.
    /// </summary>
    /// <returns>Array[AdmissionApplication]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionApplicationDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AdmissionApplication.
    /// </summary>
    /// <returns>AdmissionApplication</returns>
    /// <operationId>updateAdmissionApplication</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionApplicationDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AdmissionApplication entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAdmissionApplication</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
