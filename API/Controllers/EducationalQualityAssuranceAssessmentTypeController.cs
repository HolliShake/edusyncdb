
using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]</returns>
    [HttpGet("/Api/[controller]/chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceAssessmentType) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceAssessmentType entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceAssessmentType</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceAssessmentTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceAssessmentType.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceAssessmentType]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceAssessmentTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceAssessmentType.
    /// </summary>
    /// <returns>EducationalQualityAssuranceAssessmentType</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceAssessmentTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceAssessmentType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
