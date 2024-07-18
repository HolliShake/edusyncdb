
using APPLICATION.Dto.Enrollment;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentController : GenericController<Enrollment, IEnrollmentService, EnrollmentDto, GetEnrollmentDto>
{
    public EnrollmentController(IMapper mapper, IEnrollmentService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Enrollment]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get Enrollment by EnrollmentRole id.
    /// </summary>
    /// <returns>Array[Enrollment]</returns>
    [HttpGet("EnrollmentRole/{enrollmentRoleId:int}")]
    public async Task<ActionResult> GetEnrollmentByEnrollmentRoleId(int enrollmentRoleId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentDto>>(await _repo.GetEnrollmentsByEnrollmentRoleId(enrollmentRoleId)));
    }

    /// <summary>
    /// Get Enrollment by Schedule id.
    /// </summary>
    /// <returns>Array[Enrollment]</returns>
    [HttpGet("Schedule/{scheduleId:int}")]
    public async Task<ActionResult> GetEnrollmentByScheduleId(int scheduleId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentDto>>(await _repo.GetEnrollmentsByScheduleId(scheduleId)));
    }

    /// <summary>
    /// Get specific data (Enrollment) by id.
    /// </summary>
    /// <returns>Array[Enrollment]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Enrollment entry.
    /// </summary>
    /// <returns>Enrollment</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Enrollment.
    /// </summary>
    /// <returns>Array[Enrollment]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Enrollment.
    /// </summary>
    /// <returns>Enrollment</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Enrollment entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
