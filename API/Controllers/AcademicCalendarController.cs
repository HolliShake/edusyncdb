
using APPLICATION.Dto.AcademicCalendar;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:create")]
public class AcademicCalendarController : GenericController<AcademicCalendar, IAcademicCalendarService, AcademicCalendarDto, GetAcademicCalendarDto>
{
    public AcademicCalendarController(IMapper mapper, IAcademicCalendarService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AcademicCalendar]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AcademiCalendar by GradingPeriod Id.
    /// </summary>
    /// <returns>Array[AcademicCalendar]</returns>
    [HttpGet("GradingPeriod/{gradingPeriodId:int}")]
    public async Task<ActionResult> GetAcademicCalendarsByGradingPeriodId(int gradingPeriodId)
    {
        return Ok(await _repo.GetAcademicCalendarsByGradingPeriodId(gradingPeriodId));
    }

    /// <summary>
    /// Get specific data (AcademicCalendar) by id.
    /// </summary>
    /// <returns>Array[AcademicCalendar]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AcademicCalendar entry.
    /// </summary>
    /// <returns>AcademicCalendar</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AcademicCalendarDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AcademicCalendar.
    /// </summary>
    /// <returns>Array[AcademicCalendar]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AcademicCalendarDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AcademicCalendar.
    /// </summary>
    /// <returns>AcademicCalendar</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AcademicCalendarDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AcademicCalendar entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
