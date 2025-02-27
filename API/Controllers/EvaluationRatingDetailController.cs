using APPLICATION.Dto.EvaluationRatingDetail;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EvaluationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EvaluationRatingDetailController : GenericController<EvaluationRatingDetail, IEvaluationRatingDetailService, EvaluationRatingDetailDto, GetEvaluationRatingDetailDto>
{
    public EvaluationRatingDetailController(IMapper mapper, IEvaluationRatingDetailService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EvaluationRatingDetail]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EvaluationRatingDetail) by id.
    /// </summary>
    /// <returns>Array[EvaluationRatingDetail]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EvaluationRatingDetail entry.
    /// </summary>
    /// <returns>EvaluationRatingDetail</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EvaluationRatingDetailDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EvaluationRatingDetail.
    /// </summary>
    /// <returns>Array[EvaluationRatingDetail]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EvaluationRatingDetailDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EvaluationRatingDetail.
    /// </summary>
    /// <returns>EvaluationRatingDetail</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EvaluationRatingDetailDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EvaluationRatingDetail entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
