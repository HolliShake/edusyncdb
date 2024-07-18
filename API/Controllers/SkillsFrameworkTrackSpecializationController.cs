
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SkillsFrameworkTrackSpecializationController : GenericController<SkillsFrameworkTrackSpecialization, ISkillsFrameworkTrackSpecializationService, SkillsFrameworkTrackSpecializationDto, GetSkillsFrameworkTrackSpecializationDto>
{
    public SkillsFrameworkTrackSpecializationController(IMapper mapper, ISkillsFrameworkTrackSpecializationService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SkillsFrameworkTrackSpecialization]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get SkillsFrameworkTrackSpecialization by SectorDiscipline id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkTrackSpecialization]</returns>
    [HttpGet("SectorDiscipline/{sectorDisciplineId:int}")]
    public async Task<ActionResult> GetSkillsFrameworkTrackSpecializationBySectorDisciplineId(int sectorDisciplineId)
    {
        return Ok(await _repo.GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(sectorDisciplineId));
    }
    
    /// <summary>
    /// Get specific data (SkillsFrameworkTrackSpecialization) by id.
    /// </summary>
    /// <returns>Array[SkillsFrameworkTrackSpecialization]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SkillsFrameworkTrackSpecialization entry.
    /// </summary>
    /// <returns>SkillsFrameworkTrackSpecialization</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SkillsFrameworkTrackSpecializationDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SkillsFrameworkTrackSpecialization.
    /// </summary>
    /// <returns>Array[SkillsFrameworkTrackSpecialization]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SkillsFrameworkTrackSpecializationDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SkillsFrameworkTrackSpecialization.
    /// </summary>
    /// <returns>SkillsFrameworkTrackSpecialization</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SkillsFrameworkTrackSpecializationDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SkillsFrameworkTrackSpecialization entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
