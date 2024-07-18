
using APPLICATION.Dto.CurriculumDetail;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CurriculumDetailController : GenericController<CurriculumDetail, ICurriculumDetailService, CurriculumDetailDto, GetCurriculumDetailDto>
{
    public CurriculumDetailController(IMapper mapper, ICurriculumDetailService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CurriculumDetail]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get CurriculumDetail by Course id.
    /// </summary>
    /// <returns>Array[CurriculumDetail]</returns>
    [HttpGet("Course/{courseId:int}")]
    public async Task<ActionResult> GetByCurriculumDetailsByCourseId(int courseId)
    {
        return Ok(await _repo.GetCurriculumDetailsByCourseId(courseId));
    }
    
    /// <summary>
    /// Get specific data (CurriculumDetail) by id.
    /// </summary>
    /// <returns>Array[CurriculumDetail]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CurriculumDetail entry.
    /// </summary>
    /// <returns>CurriculumDetail</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CurriculumDetailDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of CurriculumDetail.
    /// </summary>
    /// <returns>Array[CurriculumDetail]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CurriculumDetailDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of CurriculumDetail.
    /// </summary>
    /// <returns>CurriculumDetail</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CurriculumDetailDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CurriculumDetail entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
