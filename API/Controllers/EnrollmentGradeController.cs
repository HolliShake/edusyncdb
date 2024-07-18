
using APPLICATION.Dto.EnrollmentGrade;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentGradeController : GenericController<EnrollmentGrade, IEnrollmentGradeService, EnrollmentGradeDto, GetEnrollmentGradeDto>
{
    public EnrollmentGradeController(IMapper mapper, IEnrollmentGradeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    
    /// <summary>
    /// Get specific data (EnrollmentGrade) by id.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentGrade entry.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentGradeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EnrollmentGrade.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentGradeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EnrollmentGrade.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentGradeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentGrade entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
