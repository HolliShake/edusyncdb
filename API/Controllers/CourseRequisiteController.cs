
using APPLICATION.Dto.CourseRequisite;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CourseRequisiteController : GenericController<CourseRequisite, ICourseRequisiteService, CourseRequisiteDto, GetCourseRequisiteDto>
{
    public CourseRequisiteController(IMapper mapper, ICourseRequisiteService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CourseRequisite]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get CourseRequisiteType list.
    /// </summary>
    /// <returns>Array[CourseRequisite]</returns>
    [HttpGet("ValidTypes")]
    public Task<ActionResult> GetCoursRequisiteTypes()
    {
        return Task.FromResult<ActionResult>(Ok(new List<CourseRequisiteValue> { 
            new CourseRequisiteValue(CourseRequisiteType.CoRequisite ),
            new CourseRequisiteValue(CourseRequisiteType.PreRequisite),
            new CourseRequisiteValue(CourseRequisiteType.Equivalent  )
        }));
    }

    /// <summary>
    /// Get CourseRequisite by Course id and type.
    /// </summary>
    /// <returns>Array[CourseRequisite]</returns>
    [HttpGet("Course/{courseId:int}/Type/{type:int}")]
    public async Task<ActionResult> GetCourseRequisiteByCourseAndType(int courseId, int type)
    {
        return Ok(await _repo.GetCourseRequisitesByCourseIdAndType(courseId, type));
    }
    
    /// <summary>
    /// Get specific data (CourseRequisite) by id.
    /// </summary>
    /// <returns>Array[CourseRequisite]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CourseRequisite entry.
    /// </summary>
    /// <returns>CourseRequisite</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CourseRequisiteDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of CourseRequisite.
    /// </summary>
    /// <returns>Array[CourseRequisite]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseRequisiteDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of CourseRequisite.
    /// </summary>
    /// <returns>CourseRequisite</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseRequisiteDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CourseRequisite entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
