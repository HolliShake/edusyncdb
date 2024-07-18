
using APPLICATION.Dto.BulletinScope;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class BulletinScopeController : GenericController<BulletinScope, IBulletinScopeService, BulletinScopeDto, GetBulletinScopeDto>
{
    public BulletinScopeController(IMapper mapper, IBulletinScopeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[BulletinScope]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get BulletinScope by Bulletin id.
    /// </summary>
    /// <returns>Array[BulletinScope]</returns>
    [HttpGet("Bulletin/{bulletinId:int}")]
    public async Task<ActionResult> GetBulletinScopeByBulletinId(int bulletinId)
    {
        return Ok(_mapper.Map<ICollection<GetBulletinScopeDto>>(await _repo.GetBulletinScopesByBulletinId(bulletinId)));
    }

    /// <summary>
    /// Get BulletinScope by AcademicProgram id.
    /// </summary>
    /// <returns>Array[BulletinScope]</returns>
    [HttpGet("AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetBulletinScopeByAcademicProgramId(int academicProgramId)
    {
        return Ok(_mapper.Map<ICollection<GetBulletinScopeDto>>(await _repo.GetBulletinScopesByAcademicProgramId(academicProgramId)));
    }

    /// <summary>
    /// Get specific data (BulletinScope) by id.
    /// </summary>
    /// <returns>Array[BulletinScope]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new BulletinScope entry.
    /// </summary>
    /// <returns>BulletinScope</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(BulletinScopeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of BulletinScope.
    /// </summary>
    /// <returns>Array[BulletinScope]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<BulletinScopeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of BulletinScope.
    /// </summary>
    /// <returns>BulletinScope</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, BulletinScopeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single BulletinScope entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
