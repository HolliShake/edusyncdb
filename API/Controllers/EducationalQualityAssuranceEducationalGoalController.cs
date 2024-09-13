
using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EducationalQualityAssuranceEducationalGoalController : GenericController<EducationalQualityAssuranceEducationalGoal, IEducationalQualityAssuranceEducationalGoalService, EducationalQualityAssuranceEducationalGoalDto, GetEducationalQualityAssuranceEducationalGoalDto>
{
    public EducationalQualityAssuranceEducationalGoalController(IMapper mapper, IEducationalQualityAssuranceEducationalGoalService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceEducationalGoal]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceEducationalGoal) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceEducationalGoal]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceEducationalGoal entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceEducationalGoal</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceEducationalGoalDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceEducationalGoal.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceEducationalGoal]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceEducationalGoalDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceEducationalGoal.
    /// </summary>
    /// <returns>EducationalQualityAssuranceEducationalGoal</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceEducationalGoalDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceEducationalGoal entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
