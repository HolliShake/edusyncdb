
using APPLICATION.Dto.AcademicProgramChair;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AcademicProgramChairController : GenericController<AcademicProgramChair, IAcademicProgramChairService, AcademicProgramChairDto, GetAcademicProgramChairDto>
{
    public AcademicProgramChairController(IMapper mapper, IAcademicProgramChairService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AcademicProgramChair]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (AcademicProgramChair) by id.
    /// </summary>
    /// <returns>Array[AcademicProgramChair]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AcademicProgramChair entry.
    /// </summary>
    /// <returns>AcademicProgramChair</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AcademicProgramChairDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AcademicProgramChair.
    /// </summary>
    /// <returns>Array[AcademicProgramChair]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AcademicProgramChairDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AcademicProgramChair.
    /// </summary>
    /// <returns>AcademicProgramChair</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AcademicProgramChairDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AcademicProgramChair entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
