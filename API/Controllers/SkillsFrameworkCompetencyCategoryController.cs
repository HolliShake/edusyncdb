
using APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkCompetencyCategoryController : GenericController<SkillsFrameworkCompetencyCategory, ISkillsFrameworkCompetencyCategoryService, SkillsFrameworkCompetencyCategoryDto, GetSkillsFrameworkCompetencyCategoryDto>
{
    public SkillsFrameworkCompetencyCategoryController(IMapper mapper, ISkillsFrameworkCompetencyCategoryService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyCategory]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkCompetencyCategory) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyCategory]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkCompetencyCategory entry.
    /// </summary>
    /// <returns>SkillsFrameworkCompetencyCategory</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkCompetencyCategoryDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkCompetencyCategory.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyCategory]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkCompetencyCategoryDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkCompetencyCategory.
    /// </summary>
    /// <returns>SkillsFrameworkCompetencyCategory</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkCompetencyCategoryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkCompetencyCategory entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
