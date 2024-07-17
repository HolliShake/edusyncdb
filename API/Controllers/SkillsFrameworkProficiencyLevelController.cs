
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class SkillsFrameworkProficiencyLevelController : GenericController<SkillsFrameworkProficiencyLevel, ISkillsFrameworkProficiencyLevelService, SkillsFrameworkProficiencyLevelDto, GetSkillsFrameworkProficiencyLevelDto>
{
    public SkillsFrameworkProficiencyLevelController(IMapper mapper, ISkillsFrameworkProficiencyLevelService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkProficiencyLevel]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkProficiencyLevel) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkProficiencyLevel]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkProficiencyLevel entry.
    /// </summary>
    /// <returns>SkillsFrameworkProficiencyLevel</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkProficiencyLevelDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkProficiencyLevel.
    /// </summary>
    /// <returns>Array[SkillsFrameworkProficiencyLevel]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkProficiencyLevelDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkProficiencyLevel.
    /// </summary>
    /// <returns>SkillsFrameworkProficiencyLevel</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkProficiencyLevelDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkProficiencyLevel entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
