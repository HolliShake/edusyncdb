
using APPLICATION.Dto.SkillsFrameworkGroupLevel;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkGroupLevelController : GenericController<SkillsFrameworkGroupLevel, ISkillsFrameworkGroupLevelService, SkillsFrameworkGroupLevelDto, GetSkillsFrameworkGroupLevelDto>
{
    public SkillsFrameworkGroupLevelController(IMapper mapper, ISkillsFrameworkGroupLevelService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkGroupLevel]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkGroupLevel) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkGroupLevel]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkGroupLevel entry.
    /// </summary>
    /// <returns>SkillsFrameworkGroupLevel</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkGroupLevelDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkGroupLevel.
    /// </summary>
    /// <returns>Array[SkillsFrameworkGroupLevel]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkGroupLevelDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkGroupLevel.
    /// </summary>
    /// <returns>SkillsFrameworkGroupLevel</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkGroupLevelDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkGroupLevel entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
