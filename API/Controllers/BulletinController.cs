
using APPLICATION.Dto.Bulletin;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class BulletinController : GenericController<Bulletin, IBulletinService, BulletinDto, GetBulletinDto>
{
    public BulletinController(IMapper mapper, IBulletinService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Bulletin]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get Bulletin by BulletinCategory id.
    /// </summary>
    /// <returns>Array[Bulletin]</returns>
    [HttpGet("BulletinCategory/{bulletinCategoryId:int}")]
    public async Task<ActionResult> GetBulletinByBulletinCategory(int bulletinCategoryId)
    {
        return Ok(await _repo.GetBulletinsByBulletinCategoryId(bulletinCategoryId));
    }
    
    /// <summary>
    /// Get specific data (Bulletin) by id.
    /// </summary>
    /// <returns>Array[Bulletin]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Bulletin entry.
    /// </summary>
    /// <returns>Bulletin</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(BulletinDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Bulletin.
    /// </summary>
    /// <returns>Array[Bulletin]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<BulletinDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Bulletin.
    /// </summary>
    /// <returns>Bulletin</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, BulletinDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Bulletin entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}