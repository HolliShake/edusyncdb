
using APPLICATION.Dto.EducationalQualityAssuranceType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceTypeController : GenericController<EducationalQualityAssuranceType, IEducationalQualityAssuranceTypeService, EducationalQualityAssuranceTypeDto, GetEducationalQualityAssuranceTypeDto>
{
    public EducationalQualityAssuranceTypeController(IMapper mapper, IEducationalQualityAssuranceTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceType) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceType entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceType.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceType.
    /// </summary>
    /// <returns>EducationalQualityAssuranceType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
