
using APPLICATION.Dto.SkillsFrameworkCompetencyType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkCompetencyTypeController : GenericController<SkillsFrameworkCompetencyType, ISkillsFrameworkCompetencyTypeService, SkillsFrameworkCompetencyTypeDto, GetSkillsFrameworkCompetencyTypeDto>
{
    public SkillsFrameworkCompetencyTypeController(IMapper mapper, ISkillsFrameworkCompetencyTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkCompetencyType) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkCompetencyType entry.
    /// </summary>
    /// <returns>SkillsFrameworkCompetencyType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkCompetencyTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkCompetencyType.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCompetencyType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkCompetencyTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkCompetencyType.
    /// </summary>
    /// <returns>SkillsFrameworkCompetencyType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkCompetencyTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkCompetencyType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
