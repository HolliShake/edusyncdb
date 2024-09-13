
using APPLICATION.Dto.SkillsFrameworkPerformanceExpectation;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkPerformanceExpectationController : GenericController<SkillsFrameworkPerformanceExpectation, ISkillsFrameworkPerformanceExpectationService, SkillsFrameworkPerformanceExpectationDto, GetSkillsFrameworkPerformanceExpectationDto>
{
    public SkillsFrameworkPerformanceExpectationController(IMapper mapper, ISkillsFrameworkPerformanceExpectationService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformanceExpectation]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkPerformanceExpectation) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformanceExpectation]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkPerformanceExpectation entry.
    /// </summary>
    /// <returns>SkillsFrameworkPerformanceExpectation</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkPerformanceExpectationDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkPerformanceExpectation.
    /// </summary>
    /// <returns>Array[SkillsFrameworkPerformanceExpectation]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkPerformanceExpectationDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkPerformanceExpectation.
    /// </summary>
    /// <returns>SkillsFrameworkPerformanceExpectation</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkPerformanceExpectationDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkPerformanceExpectation entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
