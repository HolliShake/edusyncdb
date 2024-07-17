
using APPLICATION.Dto.BulletinCategory;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class BulletinCategoryController : GenericController<BulletinCategory, IBulletinCategoryService, BulletinCategoryDto, GetBulletinCategoryDto>
{
    public BulletinCategoryController(IMapper mapper, IBulletinCategoryService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[BulletinCategory]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (BulletinCategory) by id.
    /// </summary>
    /// <returns>Array[BulletinCategory]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new BulletinCategory entry.
    /// </summary>
    /// <returns>BulletinCategory</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(BulletinCategoryDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of BulletinCategory.
    /// </summary>
    /// <returns>Array[BulletinCategory]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<BulletinCategoryDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of BulletinCategory.
    /// </summary>
    /// <returns>BulletinCategory</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, BulletinCategoryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single BulletinCategory entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
