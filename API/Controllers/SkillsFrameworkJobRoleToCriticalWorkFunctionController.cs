
using APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class SkillsFrameworkJobRoleToCriticalWorkFunctionController : GenericController<SkillsFrameworkJobRoleToCriticalWorkFunction, ISkillsFrameworkJobRoleToCriticalWorkFunctionService, SkillsFrameworkJobRoleToCriticalWorkFunctionDto, GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto>
{
    public SkillsFrameworkJobRoleToCriticalWorkFunctionController(IMapper mapper, ISkillsFrameworkJobRoleToCriticalWorkFunctionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToCriticalWorkFunction]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkJobRoleToCriticalWorkFunction) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToCriticalWorkFunction]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkJobRoleToCriticalWorkFunction entry.
    /// </summary>
    /// <returns>SkillsFrameworkJobRoleToCriticalWorkFunction</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkJobRoleToCriticalWorkFunctionDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkJobRoleToCriticalWorkFunction.
    /// </summary>
    /// <returns>Array[SkillsFrameworkJobRoleToCriticalWorkFunction]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkJobRoleToCriticalWorkFunctionDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkJobRoleToCriticalWorkFunction.
    /// </summary>
    /// <returns>SkillsFrameworkJobRoleToCriticalWorkFunction</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkJobRoleToCriticalWorkFunctionDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkJobRoleToCriticalWorkFunction entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
