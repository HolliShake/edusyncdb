
using APPLICATION.Dto.SkillsFrameworkSkills;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkSkillsController : GenericController<SkillsFrameworkSkills, ISkillsFrameworkSkillsService, SkillsFrameworkSkillsDto, GetSkillsFrameworkSkillsDto>
{
    public SkillsFrameworkSkillsController(IMapper mapper, ISkillsFrameworkSkillsService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkills]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkSkills) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkills]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkSkills entry.
    /// </summary>
    /// <returns>SkillsFrameworkSkills</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkSkillsDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkSkills.
    /// </summary>
    /// <returns>Array[SkillsFrameworkSkills]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkSkillsDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkSkills.
    /// </summary>
    /// <returns>SkillsFrameworkSkills</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkSkillsDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkSkills entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
