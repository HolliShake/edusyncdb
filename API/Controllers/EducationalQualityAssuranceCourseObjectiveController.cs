
using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceCourseObjective) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceCourseObjective]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceCourseObjective entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceCourseObjective</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceCourseObjectiveDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceCourseObjective.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceCourseObjective]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceCourseObjectiveDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceCourseObjective.
    /// </summary>
    /// <returns>EducationalQualityAssuranceCourseObjective</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceCourseObjectiveDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceCourseObjective entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
