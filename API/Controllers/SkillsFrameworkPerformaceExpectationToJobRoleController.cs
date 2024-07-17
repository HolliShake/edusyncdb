
using APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class SkillsFrameworkPerformaceExpectationToJobRoleController : GenericController<SkillsFrameworkPerformaceExpectationToJobRole, ISkillsFrameworkPerformaceExpectationToJobRoleService, SkillsFrameworkPerformaceExpectationToJobRoleDto, GetSkillsFrameworkPerformaceExpectationToJobRoleDto>
{
    public SkillsFrameworkPerformaceExpectationToJobRoleController(IMapper mapper, ISkillsFrameworkPerformaceExpectationToJobRoleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformaceExpectationToJobRole]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkPerformaceExpectationToJobRole) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformaceExpectationToJobRole]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkPerformaceExpectationToJobRole entry.
    /// </summary>
    /// <returns>SkillsFrameworkPerformaceExpectationToJobRole</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkPerformaceExpectationToJobRoleDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkPerformaceExpectationToJobRole.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformaceExpectationToJobRole]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkPerformaceExpectationToJobRoleDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkPerformaceExpectationToJobRole.
    /// </summary>
    /// <returns>SkillsFrameworkPerformaceExpectationToJobRole</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkPerformaceExpectationToJobRoleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkPerformaceExpectationToJobRole entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
