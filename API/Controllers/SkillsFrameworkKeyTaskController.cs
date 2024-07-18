
using APPLICATION.Dto.SkillsFrameworkKeyTask;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkKeyTaskController : GenericController<SkillsFrameworkKeyTask, ISkillsFrameworkKeyTaskService, SkillsFrameworkKeyTaskDto, GetSkillsFrameworkKeyTaskDto>
{
    public SkillsFrameworkKeyTaskController(IMapper mapper, ISkillsFrameworkKeyTaskService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkKeyTask]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkKeyTask) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkKeyTask]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkKeyTask entry.
    /// </summary>
    /// <returns>SkillsFrameworkKeyTask</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkKeyTaskDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkKeyTask.
    /// </summary>
    /// <returns>Array[SkillsFrameworkKeyTask]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkKeyTaskDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkKeyTask.
    /// </summary>
    /// <returns>SkillsFrameworkKeyTask</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkKeyTaskDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkKeyTask entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
