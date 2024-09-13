
using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceAssessmentTypeController : GenericController<EducationalQualityAssuranceAssessmentType, IEducationalQualityAssuranceAssessmentTypeService, EducationalQualityAssuranceAssessmentTypeDto, GetEducationalQualityAssuranceAssessmentTypeDto>
{
    public EducationalQualityAssuranceAssessmentTypeController(IMapper mapper, IEducationalQualityAssuranceAssessmentTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceAssessmentType) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceAssessmentType entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceAssessmentType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceAssessmentTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceAssessmentType.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceAssessmentTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceAssessmentType.
    /// </summary>
    /// <returns>EducationalQualityAssuranceAssessmentType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceAssessmentTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceAssessmentType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
