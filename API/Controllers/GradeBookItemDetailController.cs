using APPLICATION.Dto.GradeBookItemDetail;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.GradeBookData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookItemDetailController : GenericController<GradeBookItemDetail, IGradeBookItemDetailService, GradeBookItemDetailDto, GetGradeBookItemDetailDto>
{
    public GradeBookItemDetailController(IMapper mapper, IGradeBookItemDetailService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBookItemDetail]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GradeBookItemDetail) by id.
    /// </summary>
    /// <returns>Array[GradeBookItemDetail]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeBookItemDetail entry.
    /// </summary>
    /// <returns>GradeBookItemDetail</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookItemDetailDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradeBookItemDetail.
    /// </summary>
    /// <returns>Array[GradeBookItemDetail]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookItemDetailDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradeBookItemDetail.
    /// </summary>
    /// <returns>GradeBookItemDetail</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookItemDetailDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeBookItemDetail entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
