
using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

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
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AdmissionSchedule by AcademicProgram id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpGet("AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByAcademicProgramId(int academicProgramId)
    {
        return Ok(await _repo.GetAdmissionSchedulesByAcademicProgramId(academicProgramId));
    }

    /// <summary>
    /// Get AdmissionSchedule by Cycle id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpGet("Cycle/{cycleId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByCycleId(int cycleId)
    {
        return Ok(await _repo.GetAdmissionSchedulesByCycleId(cycleId));
    }
    
    /// <summary>
    /// Get specific data (AdmissionSchedule) by id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionSchedule entry.
    /// </summary>
    /// <returns>AdmissionSchedule</returns>
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
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionScheduleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionSchedule entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
