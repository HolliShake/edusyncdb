
using APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class SkillsFrameworkSkillsToCompetencyController : GenericController<SkillsFrameworkSkillsToCompetency, ISkillsFrameworkSkillsToCompetencyService, SkillsFrameworkSkillsToCompetencyDto, GetSkillsFrameworkSkillsToCompetencyDto>
{
    public SkillsFrameworkSkillsToCompetencyController(IMapper mapper, ISkillsFrameworkSkillsToCompetencyService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkillsToCompetency]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkSkillsToCompetency) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkillsToCompetency]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkSkillsToCompetency entry.
    /// </summary>
    /// <returns>SkillsFrameworkSkillsToCompetency</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkSkillsToCompetencyDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkSkillsToCompetency.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkillsToCompetency]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkSkillsToCompetencyDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkSkillsToCompetency.
    /// </summary>
    /// <returns>SkillsFrameworkSkillsToCompetency</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkSkillsToCompetencyDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkSkillsToCompetency entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
