using APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ObeAndCqi;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceProgramObjectiveToJobRoleController : GenericController<EducationalQualityAssuranceProgramObjectiveToJobRole, IEducationalQualityAssuranceProgramObjectiveToJobRoleService, EducationalQualityAssuranceProgramObjectiveToJobRoleDto, GetEducationalQualityAssuranceProgramObjectiveToJobRoleDto>
{
    public EducationalQualityAssuranceProgramObjectiveToJobRoleController(IMapper mapper, IEducationalQualityAssuranceProgramObjectiveToJobRoleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjectiveToJobRole]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /*
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjectiveToJobRole]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    */
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceProgramObjectiveToJobRole) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjectiveToJobRole]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceProgramObjectiveToJobRole entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceProgramObjectiveToJobRole</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceProgramObjectiveToJobRoleDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceProgramObjectiveToJobRole.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceProgramObjectiveToJobRole]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceProgramObjectiveToJobRoleDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceProgramObjectiveToJobRole.
    /// </summary>
    /// <returns>EducationalQualityAssuranceProgramObjectiveToJobRole</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceProgramObjectiveToJobRoleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceProgramObjectiveToJobRole entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
