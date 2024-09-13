
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AdmissionEvaluationScheduleController : GenericController<AdmissionEvaluationSchedule, IAdmissionEvaluationScheduleService, AdmissionEvaluationScheduleDto, GetAdmissionEvaluationScheduleDto>
{
    public AdmissionEvaluationScheduleController(IMapper mapper, IAdmissionEvaluationScheduleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionEvaluationSchedule]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AdmissionEvaluationSchedule by AdmissionSchedule id.
    /// </summary>
    /// <returns>Array[AdmissionEvaluationSchedule]</returns>
    [HttpGet("AdmissionSchedule/{admissionScheduleId:int}")]
    public async Task<ActionResult> GetAdmissionEvaluationScheduleByAdmissionScheduleId(int admissionScheduleId)
    {
        return Ok(await _repo.GetAdmissionEvaluationSchedulesByAdmissionScheduleId(admissionScheduleId));
    }
    
    /// <summary>
    /// Get specific data (AdmissionEvaluationSchedule) by id.
    /// </summary>
    /// <returns>Array[AdmissionEvaluationSchedule]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionEvaluationSchedule entry.
    /// </summary>
    /// <returns>AdmissionEvaluationSchedule</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionEvaluationScheduleDto item)
    {
        if (!item.IsOnlineMode)
        {
            if (item.EvaluationLocation != null)
            {
                if (item.EvaluationLocation.Length > 0)
                {
                    goto ok;
                }
            }

            return BadRequest("EvaluationLocation is required when not online mode.");
        }
        else
        {
            if (item.EvaluationOnlineLink != null)
            {
                if (item.EvaluationOnlineLink.Length > 0)
                {
                    goto ok;
                }
            }

            return BadRequest("EvaluationOnlineLine is required when online mode.");
        }

        ok:;
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of AdmissionEvaluationSchedule.
    /// </summary>
    /// <returns>Array[AdmissionEvaluationSchedule]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionEvaluationScheduleDto> items)
    {
        foreach (var item in items)
        {
            if (!item.IsOnlineMode)
            {
                if (item.EvaluationLocation != null)
                {
                    if (item.EvaluationLocation.Length > 0)
                    {
                        continue;
                    }
                }

                return BadRequest("EvaluationLocation is required when not online mode.");
            }
            else
            {
                if (item.EvaluationOnlineLink != null)
                {
                    if (item.EvaluationOnlineLink.Length > 0)
                    {
                        continue;
                    }
                }

                return BadRequest("EvaluationOnlineLine is required when online mode.");
            }
        }

        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of AdmissionEvaluationSchedule.
    /// </summary>
    /// <returns>AdmissionEvaluationSchedule</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionEvaluationScheduleDto item)
    {
        if (!item.IsOnlineMode)
        {
            if (item.EvaluationLocation != null)
            {
                if (item.EvaluationLocation.Length > 0)
                {
                    goto ok;
                }
            }

            return BadRequest("EvaluationLocation is required when not online mode.");
        }
        else
        {
            if (item.EvaluationOnlineLink != null)
            {
                if (item.EvaluationOnlineLink.Length > 0)
                {
                    goto ok;
                }
            }

            return BadRequest("EvaluationOnlineLine is required when online mode.");
        }

        ok:;
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionEvaluationSchedule entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
