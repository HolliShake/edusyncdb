
using APPLICATION.Dto.GradeBookScore;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookScoreController : GenericController<GradeBookScore, IGradeBookScoreService, GradeBookScoreDto, GetGradeBookScoreDto>
{
    public GradeBookScoreController(IMapper mapper, IGradeBookScoreService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBookScore]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GradeBookScore) by id.
    /// </summary>
    /// <returns>Array[GradeBookScore]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeBookScore entry.
    /// </summary>
    /// <returns>GradeBookScore</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookScoreDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of GradeBookScore.
    /// </summary>
    /// <returns>Array[GradeBookScore]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookScoreDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of GradeBookScore.
    /// </summary>
    /// <returns>GradeBookScore</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookScoreDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeBookScore entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
