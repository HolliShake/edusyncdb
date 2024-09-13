
using APPLICATION.Dto.LikertQuestion;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class LikertQuestionController : GenericController<LikertQuestion, ILikertQuestionService, LikertQuestionDto, GetLikertQuestionDto>
{
    public LikertQuestionController(IMapper mapper, ILikertQuestionService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[LikertQuestion]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (LikertQuestion) by id.
    /// </summary>
    /// <returns>Array[LikertQuestion]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new LikertQuestion entry.
    /// </summary>
    /// <returns>LikertQuestion</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(LikertQuestionDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of LikertQuestion.
    /// </summary>
    /// <returns>Array[LikertQuestion]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<LikertQuestionDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of LikertQuestion.
    /// </summary>
    /// <returns>LikertQuestion</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, LikertQuestionDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single LikertQuestion entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
