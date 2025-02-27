using APPLICATION.Dto.ScholarshipList;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.ScholarshipData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ScholarshipListController : GenericController<ScholarshipList, IScholarshipListService, ScholarshipListDto, GetScholarshipListDto>
{
    public ScholarshipListController(IMapper mapper, IScholarshipListService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ScholarshipList]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ScholarshipList) by id.
    /// </summary>
    /// <returns>Array[ScholarshipList]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ScholarshipList entry.
    /// </summary>
    /// <returns>ScholarshipList</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ScholarshipListDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ScholarshipList.
    /// </summary>
    /// <returns>Array[ScholarshipList]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ScholarshipListDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ScholarshipList.
    /// </summary>
    /// <returns>ScholarshipList</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ScholarshipListDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ScholarshipList entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
