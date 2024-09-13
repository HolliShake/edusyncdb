
using APPLICATION.Dto.CourseToLearningObjectiveMapping;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CourseToLearningObjectiveMappingController : GenericController<CourseToLearningObjectiveMapping, ICourseToLearningObjectiveMappingService, CourseToLearningObjectiveMappingDto, GetCourseToLearningObjectiveMappingDto>
{
    public CourseToLearningObjectiveMappingController(IMapper mapper, ICourseToLearningObjectiveMappingService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CourseToLearningObjectiveMapping]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (CourseToLearningObjectiveMapping) by id.
    /// </summary>
    /// <returns>Array[CourseToLearningObjectiveMapping]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CourseToLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>CourseToLearningObjectiveMapping</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CourseToLearningObjectiveMappingDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of CourseToLearningObjectiveMapping.
    /// </summary>
    /// <returns>Array[CourseToLearningObjectiveMapping]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseToLearningObjectiveMappingDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of CourseToLearningObjectiveMapping.
    /// </summary>
    /// <returns>CourseToLearningObjectiveMapping</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseToLearningObjectiveMappingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CourseToLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
