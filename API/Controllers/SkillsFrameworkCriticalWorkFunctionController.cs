
using APPLICATION.Dto.SkillsFrameworkCriticalWorkFunction;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkCriticalWorkFunctionController : GenericController<SkillsFrameworkCriticalWorkFunction, ISkillsFrameworkCriticalWorkFunctionService, SkillsFrameworkCriticalWorkFunctionDto, GetSkillsFrameworkCriticalWorkFunctionDto>
{
    public SkillsFrameworkCriticalWorkFunctionController(IMapper mapper, ISkillsFrameworkCriticalWorkFunctionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCriticalWorkFunction]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkCriticalWorkFunction) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCriticalWorkFunction]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkCriticalWorkFunction entry.
    /// </summary>
    /// <returns>SkillsFrameworkCriticalWorkFunction</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkCriticalWorkFunctionDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkCriticalWorkFunction.
    /// </summary>
    /// <returns>Array[SkillsFrameworkCriticalWorkFunction]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkCriticalWorkFunctionDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkCriticalWorkFunction.
    /// </summary>
    /// <returns>SkillsFrameworkCriticalWorkFunction</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkCriticalWorkFunctionDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkCriticalWorkFunction entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
