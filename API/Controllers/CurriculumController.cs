using APPLICATION.Dto.Curriculum;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class CurriculumController : GenericController<Curriculum, ICurriculumService, CurriculumDto, GetCurriculumDto>
{
    public CurriculumController(IMapper mapper, ICurriculumService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Curriculum]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get Curriculum by AcademicProgram id.
    /// </summary>
    /// <returns>Array[Curriculum]</returns>
    [HttpGet("/Api/[controller]/AcademicProgram/{academicProgramId:int}")]
    public async Task<ActionResult> GetCurriculumByAcademicProgramId(int academicProgramId)
    {
        return Ok(_mapper.Map<ICollection<GetCurriculumDto>>(await _repo.GetCurriculumByAcademicProgramId(academicProgramId)));
    }
    
    /// <summary>
    /// Get specific data (Curriculum) by id.
    /// </summary>
    /// <returns>Array[Curriculum]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Curriculum entry.
    /// </summary>
    /// <returns>Curriculum</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(CurriculumDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Curriculum.
    /// </summary>
    /// <returns>Array[Curriculum]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<CurriculumDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Curriculum.
    /// </summary>
    /// <returns>Curriculum</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CurriculumDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Curriculum entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
