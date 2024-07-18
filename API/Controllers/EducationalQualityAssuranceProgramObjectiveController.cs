
using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceProgramObjectiveController : GenericController<EducationalQualityAssuranceProgramObjective, IEducationalQualityAssuranceProgramObjectiveService, EducationalQualityAssuranceProgramObjectiveDto, GetEducationalQualityAssuranceProgramObjectiveDto>
{
    public EducationalQualityAssuranceProgramObjectiveController(IMapper mapper, IEducationalQualityAssuranceProgramObjectiveService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjective]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceProgramObjective) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjective]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceProgramObjective entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceProgramObjective</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceProgramObjectiveDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceProgramObjective.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjective]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceProgramObjectiveDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceProgramObjective.
    /// </summary>
    /// <returns>EducationalQualityAssuranceProgramObjective</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceProgramObjectiveDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceProgramObjective entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
