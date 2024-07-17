
using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EducationalQualityAssuranceEducationalGoal) by id.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceEducationalGoal]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EducationalQualityAssuranceEducationalGoal entry.
    /// </summary>
    /// <returns>EducationalQualityAssuranceEducationalGoal</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(EducationalQualityAssuranceEducationalGoalDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EducationalQualityAssuranceEducationalGoal.
    /// </summary>
    /// <returns>Array[EducationalQualityAssuranceEducationalGoal]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<EducationalQualityAssuranceEducationalGoalDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EducationalQualityAssuranceEducationalGoal.
    /// </summary>
    /// <returns>EducationalQualityAssuranceEducationalGoal</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EducationalQualityAssuranceEducationalGoalDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EducationalQualityAssuranceEducationalGoal entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
