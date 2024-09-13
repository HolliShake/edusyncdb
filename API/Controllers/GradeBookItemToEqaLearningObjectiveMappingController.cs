
using APPLICATION.Dto.GradeBookItemToEqaLearningObjectiveMapping;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookItemToEqaLearningObjectiveMappingController : GenericController<GradeBookItemToEqaLearningObjectiveMapping, IGradeBookItemToEqaLearningObjectiveMappingService, GradeBookItemToEqaLearningObjectiveMappingDto, GetGradeBookItemToEqaLearningObjectiveMappingDto>
{
    public GradeBookItemToEqaLearningObjectiveMappingController(IMapper mapper, IGradeBookItemToEqaLearningObjectiveMappingService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBookItemToEqaLearningObjectiveMapping]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GradeBookItemToEqaLearningObjectiveMapping) by id.
    /// </summary>
    /// <returns>Array[GradeBookItemToEqaLearningObjectiveMapping]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeBookItemToEqaLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>GradeBookItemToEqaLearningObjectiveMapping</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookItemToEqaLearningObjectiveMappingDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradeBookItemToEqaLearningObjectiveMapping.
    /// </summary>
    /// <returns>Array[GradeBookItemToEqaLearningObjectiveMapping]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookItemToEqaLearningObjectiveMappingDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradeBookItemToEqaLearningObjectiveMapping.
    /// </summary>
    /// <returns>GradeBookItemToEqaLearningObjectiveMapping</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookItemToEqaLearningObjectiveMappingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeBookItemToEqaLearningObjectiveMapping entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
