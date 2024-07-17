
using APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class SkillsFrameworkJobRoleToProficiencyLevelController : GenericController<SkillsFrameworkJobRoleToProficiencyLevel, ISkillsFrameworkJobRoleToProficiencyLevelService, SkillsFrameworkJobRoleToProficiencyLevelDto, GetSkillsFrameworkJobRoleToProficiencyLevelDto>
{
    public SkillsFrameworkJobRoleToProficiencyLevelController(IMapper mapper, ISkillsFrameworkJobRoleToProficiencyLevelService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToProficiencyLevel]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkJobRoleToProficiencyLevel) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToProficiencyLevel]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkJobRoleToProficiencyLevel entry.
    /// </summary>
    /// <returns>SkillsFrameworkJobRoleToProficiencyLevel</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkJobRoleToProficiencyLevelDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkJobRoleToProficiencyLevel.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToProficiencyLevel]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkJobRoleToProficiencyLevelDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkJobRoleToProficiencyLevel.
    /// </summary>
    /// <returns>SkillsFrameworkJobRoleToProficiencyLevel</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkJobRoleToProficiencyLevelDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkJobRoleToProficiencyLevel entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
