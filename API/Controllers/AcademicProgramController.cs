
using APPLICATION.Dto.AcademicProgram;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AcademicProgramController : GenericController<AcademicProgram, IAcademicProgramService, AcademicProgramDto, GetAcademicProgramDto>
{
    public AcademicProgramController(IMapper mapper, IAcademicProgramService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AcademicProgram]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
   
    /// <summary>
    /// Get specific data (AcademicProgram) by id.
    /// </summary>
    /// <returns>Array[AcademicProgram]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AcademicProgram entry.
    /// </summary>
    /// <returns>AcademicProgram</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AcademicProgramDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AcademicProgram.
    /// </summary>
    /// <returns>Array[AcademicProgram]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AcademicProgramDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AcademicProgram.
    /// </summary>
    /// <returns>AcademicProgram</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AcademicProgramDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AcademicProgram entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
