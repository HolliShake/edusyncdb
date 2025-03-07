using APPLICATION.Dto.EvaluationPeriod;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EvaluationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EvaluationPeriodController : GenericController<EvaluationPeriod, IEvaluationPeriodService, EvaluationPeriodDto, GetEvaluationPeriodDto>
{
    public EvaluationPeriodController(IMapper mapper, IEvaluationPeriodService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EvaluationPeriod]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EvaluationPeriod) by id.
    /// </summary>
    /// <returns>Array[EvaluationPeriod]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Get EvaluationPeriod information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Instrument/info/{id:int}")]
    public async Task<ActionResult> GetEvaluationPeriodInformation(int id)
    {
        var result = await _repo.GetEvaluationPeriodInformation(id);
        return (result != null)
            ? Ok(result)
            : NotFound("EvaluationPeriod not found");
    }

    /// <summary>
    /// Creates new EvaluationPeriod entry.
    /// </summary>
    /// <returns>EvaluationPeriod</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EvaluationPeriodDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EvaluationPeriod.
    /// </summary>
    /// <returns>Array[EvaluationPeriod]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EvaluationPeriodDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EvaluationPeriod.
    /// </summary>
    /// <returns>EvaluationPeriod</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EvaluationPeriodDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EvaluationPeriod entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
