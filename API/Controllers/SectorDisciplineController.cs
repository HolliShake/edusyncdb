
using APPLICATION.Dto.SectorDiscipline;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class SectorDisciplineController : GenericController<SectorDiscipline, ISectorDisciplineService, SectorDisciplineDto, GetSectorDisciplineDto>
{
    public SectorDisciplineController(IMapper mapper, ISectorDisciplineService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get all SectorDiscipline without parent.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpGet("IsParent/all")]
    public async Task<ActionResult> GetParentSectorDiscipline()
    {
        return Ok(await _repo.GetAllParentSectorDiscipline());
    }

    /// <summary>
    /// Get SectorDiscipline by ParentSectorDiscipline id.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpGet("ParentSectorDiscipline/{parentSectorDisciplineId:int}")]
    public async Task<ActionResult> GetSectorDisciplineByParentSectorDisciplineId(int parentSectorDisciplineId)
    {
        return Ok(await _repo.GetSectorDisciplineByParentSectorDisciplineId(parentSectorDisciplineId));
    }

    /// <summary>
    /// Get specific data (SectorDiscipline) by id.
    /// </summary>
    /// <returns>Array[SectorDiscipline]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SectorDiscipline entry.
    /// </summary>
    /// <returns>SectorDiscipline</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(SectorDisciplineDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of SectorDiscipline.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<SectorDisciplineDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of SectorDiscipline.
    /// </summary>
    /// <returns>SectorDiscipline</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SectorDisciplineDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SectorDiscipline entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
