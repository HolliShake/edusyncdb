
using APPLICATION.Dto.CourseToLearningObjectiveMapping;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (CourseToLearningObjectiveMapping) by id.
    /// </summary>
    /// <returns>Array[CourseToLearningObjectiveMapping]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CourseToLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>CourseToLearningObjectiveMapping</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(CourseToLearningObjectiveMappingDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of CourseToLearningObjectiveMapping.
    /// </summary>
    /// <returns>Array[CourseToLearningObjectiveMapping]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseToLearningObjectiveMappingDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of CourseToLearningObjectiveMapping.
    /// </summary>
    /// <returns>CourseToLearningObjectiveMapping</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseToLearningObjectiveMappingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CourseToLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
