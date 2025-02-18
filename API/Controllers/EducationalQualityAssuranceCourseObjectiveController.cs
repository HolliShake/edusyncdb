using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ObeAndCqi;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceCourseObjectiveController : GenericController<EducationalQualityAssuranceCourseObjective, IEducationalQualityAssuranceCourseObjectiveService, EducationalQualityAssuranceCourseObjectiveDto, GetEducationalQualityAssuranceCourseObjectiveDto>
{
    public EducationalQualityAssuranceCourseObjectiveController(IMapper mapper, IEducationalQualityAssuranceCourseObjectiveService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceCourseObjective]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceCourseObjective) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceCourseObjective]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceCourseObjective entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceCourseObjective</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceCourseObjectiveDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceCourseObjective.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceCourseObjective]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceCourseObjectiveDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceCourseObjective.
    /// </summary>
    /// <returns>EducationalQualityAssuranceCourseObjective</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceCourseObjectiveDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceCourseObjective entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
