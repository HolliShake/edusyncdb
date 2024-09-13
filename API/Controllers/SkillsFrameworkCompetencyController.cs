
using APPLICATION.Dto.SkillsFrameworkCompetency;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkCompetencyController : GenericController<SkillsFrameworkCompetency, ISkillsFrameworkCompetencyService, SkillsFrameworkCompetencyDto, GetSkillsFrameworkCompetencyDto>
{
    public SkillsFrameworkCompetencyController(IMapper mapper, ISkillsFrameworkCompetencyService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetency]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkCompetency) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetency]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkCompetency entry.
    /// </summary>
    /// <returns>SkillsFrameworkCompetency</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkCompetencyDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkCompetency.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetency]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkCompetencyDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkCompetency.
    /// </summary>
    /// <returns>SkillsFrameworkCompetency</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkCompetencyDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkCompetency entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
