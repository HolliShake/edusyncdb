using APPLICATION.Dto.Course;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CourseCatalogData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CourseController : GenericController<Course, ICourseService, CourseDto, GetCourseDto>
{
    public CourseController(IMapper mapper, ICourseService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data (without requisites)..
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all data (with requisites).
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("WithRequisite/all")]
    public async Task<ActionResult> GetAllWithRequisiteAction()
    {
        var result = /**/
            await _repo.GetAllWithRequisiteAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get all data grouped by TrackSpecialization.
    /// </summary>
    /// <returns></returns>
    [HttpGet("TrackSpecialization")]
    public async Task<ActionResult> GetAllCourseGroupByTrackSpecialization()
    {
        return Ok(await _repo.GetAllCourseGroupByTrackSpecialization());
    }

    /// <summary>
    /// Get Course by EducationalQualityAssuranceType id (without requisites).
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("EducationalQualityAssuranceType/{educationalQualityAssuranceTypeId:int}")]
    public async Task<ActionResult> GetCourseByEducationalQualityAssuranceId(int educationalQualityAssuranceTypeId)
    {
        return Ok(await _repo.GetCourseByEducationalQualityAssuranceType(educationalQualityAssuranceTypeId, false));
    }

    /// <summary>
    /// Get Course by EducationalQualityAssuranceType id (with requisites).
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("EducationalQualityAssuranceType/WithRequisite/{educationalQualityAssuranceTypeId:int}")]
    public async Task<ActionResult> GetCourseWithRequisiteByEducationalQualityAssuranceId(int educationalQualityAssuranceTypeId)
    {
        return Ok(await _repo.GetCourseByEducationalQualityAssuranceType(educationalQualityAssuranceTypeId, true));
    }

    /// <summary>
    /// Get Course by SkillsFrameworkTrackSpecialization id (without requisites).
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("SkillsFrameworkTrackSpecialization/{trackSpecializationId:int}")]
    public async Task<ActionResult> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId)
    {
        return Ok(await _repo.GetCourseBySkillsFrameworkTrackSpecializationId(trackSpecializationId, false));
    }

    /// <summary>
    /// Get Course by SkillsFrameworkTrackSpecialization id (with requisites).
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpGet("SkillsFrameworkTrackSpecialization/WithRequisite/{trackSpecializationId:int}")]
    public async Task<ActionResult> GetCourseWithRequisiteBySkillsFrameworkTrackSpecializationId(int trackSpecializationId)
    {
        return Ok(await _repo.GetCourseBySkillsFrameworkTrackSpecializationId(trackSpecializationId, true));
    }

    /// <summary>
    /// Get specific data (Course) by id (without requisites).
    /// </summary>
    /// <returns>Array[Course]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Get specific data (Course) by id (with requisites).
    /// </summary>
    /// <returns>Array[Course]></returns>
    [HttpGet("WithRequisite/{id:int}")]
    public async Task<ActionResult> GetWithRequisiteAction(int id)
    {
        var result = /**/
           await _repo.GetWithRequisiteAsync(id);

        return (result != null)
            ? Ok(result)
            : NotFound();
    }

    /// <summary>
    /// Creates new Course entry.
    /// </summary>
    /// <returns>Course</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CourseDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of Course.
    /// </summary>
    /// <returns>Array[Course]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of Course.
    /// </summary>
    /// <returns>Course</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Course entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
