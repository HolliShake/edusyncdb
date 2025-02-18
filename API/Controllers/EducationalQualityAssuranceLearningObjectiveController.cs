using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ObeAndCqi;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceLearningObjectiveController : GenericController<EducationalQualityAssuranceLearningObjective, IEducationalQualityAssuranceLearningObjectiveService, EducationalQualityAssuranceLearningObjectiveDto, GetEducationalQualityAssuranceLearningObjectiveDto>
{
    public EducationalQualityAssuranceLearningObjectiveController(IMapper mapper, IEducationalQualityAssuranceLearningObjectiveService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceLearningObjective]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceLearningObjective) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceLearningObjective]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceLearningObjective entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceLearningObjective</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceLearningObjectiveDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceLearningObjective.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceLearningObjective]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceLearningObjectiveDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceLearningObjective.
    /// </summary>
    /// <returns>EducationalQualityAssuranceLearningObjective</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceLearningObjectiveDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceLearningObjective entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
