
using APPLICATION.Dto.ScholarshipEvaluation;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class ScholarshipEvaluationController : GenericController<ScholarshipEvaluation, IScholarshipEvaluationService, ScholarshipEvaluationDto, GetScholarshipEvaluationDto>
{
    public ScholarshipEvaluationController(IMapper mapper, IScholarshipEvaluationService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScholarshipEvaluation]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScholarshipEvaluation) by id.
    /// </summary>
    /// <returns>Array[ScholarshipEvaluation]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScholarshipEvaluation entry.
    /// </summary>
    /// <returns>ScholarshipEvaluation</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(ScholarshipEvaluationDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ScholarshipEvaluation.
    /// </summary>
    /// <returns>Array[ScholarshipEvaluation]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<ScholarshipEvaluationDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ScholarshipEvaluation.
    /// </summary>
    /// <returns>ScholarshipEvaluation</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScholarshipEvaluationDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScholarshipEvaluation entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
