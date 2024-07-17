
using APPLICATION.Dto.SectorDiscipline;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get all SectorDiscipline without parent.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpGet("/Api/[controller]/IsParent/all")]
    public async Task<ActionResult> GetParentSectorDiscipline()
    {
        return Ok(_mapper.Map<ICollection<GetSectorDisciplineDto>>(await _repo.GetAllParentSectorDiscipline()));
    }

    /// <summary>
    /// Get SectorDiscipline by ParentSectorDiscipline id.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpGet("/Api/[controller]/ParentSectorDiscipline/{parentSectorDisciplineId:int}")]
    public async Task<ActionResult> GetSectorDisciplineByParentSectorDisciplineId(int parentSectorDisciplineId)
    {
        return Ok(_mapper.Map<ICollection<GetSectorDisciplineDto>>(await _repo.GetSectorDisciplineByParentSectorDisciplineId(parentSectorDisciplineId)));
    }

    /// <summary>
    /// Get specific data (SectorDiscipline) by id.
    /// </summary>
    /// <returns>Array[SectorDiscipline]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new SectorDiscipline entry.
    /// </summary>
    /// <returns>SectorDiscipline</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(SectorDisciplineDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of SectorDiscipline.
    /// </summary>
    /// <returns>Array[SectorDiscipline]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<SectorDisciplineDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of SectorDiscipline.
    /// </summary>
    /// <returns>SectorDiscipline</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, SectorDisciplineDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single SectorDiscipline entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
