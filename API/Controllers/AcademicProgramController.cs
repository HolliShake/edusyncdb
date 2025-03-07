using APPLICATION.Dto.AcademicProgram;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

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
    /// <operationId>getAllAcademicProgram</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get AcademicProgram by CampusId.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns>Array[AcademicProgram]</returns>
    [HttpGet("Campus/{campusId:int}")]
    public async Task<ActionResult> GetAcademicProgramByCampusId(int campusId)
    {
        return Ok(await _repo.GetAcademicProgramByCampusId(campusId));
    }

    /// <summary>
    /// Get AcademicProgram by CollegeId.
    /// </summary>
    /// <param name="campusId"></param>
    /// <returns>Array[AcademicProgram]</returns>
    [HttpGet("College/{collegeId:int}")]
    public async Task<ActionResult> GetAcademicProgramByCollegeId(int collegeId)
    {
        return Ok(await _repo.GetAcademicProgramByCollegeId(collegeId));
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
    
    /*
    /// <summary>
    /// Creates multiple instance of AcademicProgram.
    /// </summary>
    /// <returns>Array[AcademicProgram]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AcademicProgramDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
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
