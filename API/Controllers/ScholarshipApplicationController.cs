
using APPLICATION.Dto.ScholarshipApplication;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScholarshipApplicationController : GenericController<ScholarshipApplication, IScholarshipApplicationService, ScholarshipApplicationDto, GetScholarshipApplicationDto>
{
    public ScholarshipApplicationController(IMapper mapper, IScholarshipApplicationService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScholarshipApplication]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScholarshipApplication) by id.
    /// </summary>
    /// <returns>Array[ScholarshipApplication]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScholarshipApplication entry.
    /// </summary>
    /// <returns>ScholarshipApplication</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScholarshipApplicationDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScholarshipApplication.
    /// </summary>
    /// <returns>Array[ScholarshipApplication]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScholarshipApplicationDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScholarshipApplication.
    /// </summary>
    /// <returns>ScholarshipApplication</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScholarshipApplicationDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScholarshipApplication entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
