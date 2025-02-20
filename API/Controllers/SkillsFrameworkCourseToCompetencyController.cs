using APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ObeAndCqi;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkCourseToCompetencyController : GenericController<SkillsFrameworkCourseToCompetency, ISkillsFrameworkCourseToCompetencyService, SkillsFrameworkCourseToCompetencyDto, GetSkillsFrameworkCourseToCompetencyDto>
{
    public SkillsFrameworkCourseToCompetencyController(IMapper mapper, ISkillsFrameworkCourseToCompetencyService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCourseToCompetency]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkCourseToCompetency) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCourseToCompetency]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkCourseToCompetency entry.
    /// </summary>
    /// <returns>SkillsFrameworkCourseToCompetency</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkCourseToCompetencyDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkCourseToCompetency.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCourseToCompetency]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkCourseToCompetencyDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkCourseToCompetency.
    /// </summary>
    /// <returns>SkillsFrameworkCourseToCompetency</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkCourseToCompetencyDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkCourseToCompetency entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
