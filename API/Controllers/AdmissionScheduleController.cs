using APPLICATION.Dto.AdmissionSchedule;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.AdmissionData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionScheduleController : GenericController<AdmissionSchedule, IAdmissionScheduleService, AdmissionScheduleDto, GetAdmissionScheduleDto>
{
    public AdmissionScheduleController(IMapper mapper, IAdmissionScheduleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    /// <operationId>getAllAdmissionSchedule</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AdmissionSchedule by AcademicProgram id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns
    /// <operationId>getAllAdmissionScheduleByAcademicProgramId</operationId>
    [HttpGet("AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByAcademicProgramId(int academicProgramId)
    {
        return Ok(await _repo.GetAdmissionSchedulesByAcademicProgramId(academicProgramId));
    }

    /// <summary>
    /// Get AdmissionSchedule by Cycle id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    /// <operationId>getAdmissionScheduleByCycleId</operationId>
    [HttpGet("Cycle/{cycleId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByCycleId(int cycleId)
    {
        return Ok(await _repo.GetAdmissionSchedulesByCycleId(cycleId));
    }

    /// <summary>
    /// Get Open admission schedule by Agency id or School Id 
    /// </summary>
    /// <param name="schoolId"></param>
    /// <returns>Array[AdmissionSchedule]</returns>
    /// <operationId>getPublicOpenAdmissionScheduleBySchoolId</operationId>
    [HttpGet("Public/Open/{schoolId:int}")]
    public async Task<ActionResult> GetOpenAdmissionSchedule(int schoolId)
    {
        var items = await _repo.GetOpenAdmissionScheduleGroupedByCampus(schoolId);
        return Ok(items);
    }

    /// <summary>
    /// Get Open admission schedule by Campus shortname
    /// </summary>
    /// <param name="campusShortName"></param>
    /// <returns>Array[AdmissionSchedule]</returns>
    /// <operationId>getAdmissionScheduleByCampusShortName</operationId>
    [HttpGet("Public/Open/{campusShortName}")]
    public async Task<ActionResult> GetOpenAdmissionSchedule(string campusShortName)
    {
        var items = await _repo.GetOpenAdmissionScheduleGroupedByCampusViaCampusName(campusShortName);
        return Ok(items);
    }

    /// <summary>
    /// Get specific data (AdmissionSchedule) by id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]></returns>
    /// <operationId>getAdmissionScheduleById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AdmissionSchedule entry.
    /// </summary>
    /// <returns>AdmissionSchedule</returns>
    /// <operationId>createAdmissionSchedule</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionScheduleDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AdmissionSchedule.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionScheduleDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AdmissionSchedule.
    /// </summary>
    /// <returns>AdmissionSchedule</returns>
    /// <operationId>updateAdmissionSchedule</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionScheduleDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AdmissionSchedule entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAdmissionSchedule</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
