
using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AdmissionSchedule by AcademicProgram id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpGet("/Api/[controller]/AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByAcademicProgramId(int academicProgramId)
    {
        return Ok(_mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _repo.GetAdmissionSchedulesByAcademicProgramId(academicProgramId)));
    }

    /// <summary>
    /// Get AdmissionSchedule by Cycle id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpGet("/Api/[controller]/Cycle/{cycleId:int}")]
    public async Task<ActionResult> GetAdmissionScheduleByCycleId(int cycleId)
    {
        return Ok(_mapper.Map<ICollection<GetAdmissionScheduleDto>>(await _repo.GetAdmissionSchedulesByCycleId(cycleId)));
    }
    
    /// <summary>
    /// Get specific data (AdmissionSchedule) by id.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionSchedule entry.
    /// </summary>
    /// <returns>AdmissionSchedule</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(AdmissionScheduleDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AdmissionSchedule.
    /// </summary>
    /// <returns>Array[AdmissionSchedule]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionScheduleDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AdmissionSchedule.
    /// </summary>
    /// <returns>AdmissionSchedule</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionScheduleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionSchedule entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
