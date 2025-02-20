using APPLICATION.Dto.EvaluationRating;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EvaluationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EvaluationRatingController : GenericController<EvaluationRating, IEvaluationRatingService, EvaluationRatingDto, GetEvaluationRatingDto>
{
    public EvaluationRatingController(IMapper mapper, IEvaluationRatingService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EvaluationRating]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EvaluationRating) by id.
    /// </summary>
    /// <returns>Array[EvaluationRating]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new EvaluationRating entry.
    /// </summary>
    /// <returns></returns>
    [HttpPost("create/EvaluationRating")]
    public async Task<ActionResult> CreateEvaluationRating(EvaluationRatingGroupDto item)
    {
        return Ok(await _repo.CreateEvaluationRatingScore(item));
    }

    /// <summary>
    /// Post EvaluationRating entry.
    /// </summary>
    /// <param name="evaluationPeriodId"></param>
    /// <returns></returns>
    [HttpPost("post/EvaluationPeriod/{evaluationPeriodId:int}")]
    public async Task<ActionResult> PostEvaluationRating(int evaluationPeriodId)
    {
        return Ok(await _repo.UpdatePostedPostStatusByEvaluationPeriodId(evaluationPeriodId, true));
    }

    /// <summary>
    /// UnPost EvaluationRating entry.
    /// </summary>
    /// <param name="evaluationPeriodId"></param>
    /// <returns></returns>
    [HttpPost("unpost/EvaluationPeriod/{evaluationPeriodId:int}")]
    public async Task<ActionResult> UnPostEvaluationRating(int evaluationPeriodId)
    {
        return Ok(await _repo.UpdatePostedPostStatusByEvaluationPeriodId(evaluationPeriodId, false));
    }

    /// <summary>
    /// Creates new EvaluationRating entry.
    /// </summary>
    /// <returns>EvaluationRating</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EvaluationRatingDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EvaluationRating.
    /// </summary>
    /// <returns>Array[EvaluationRating]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EvaluationRatingDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EvaluationRating.
    /// </summary>
    /// <returns>EvaluationRating</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EvaluationRatingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EvaluationRating entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
