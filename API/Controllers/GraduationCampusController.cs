using APPLICATION.Dto.GraduationCampus;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.GraduateData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GraduationCampusController : GenericController<GraduationCampus, IGraduationCampusService, GraduationCampusDto, GetGraduationCampusDto>
{
    public GraduationCampusController(IMapper mapper, IGraduationCampusService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GraduationCampus]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GraduationCampus) by id.
    /// </summary>
    /// <returns>Array[GraduationCampus]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GraduationCampus entry.
    /// </summary>
    /// <returns>GraduationCampus</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GraduationCampusDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GraduationCampus.
    /// </summary>
    /// <returns>Array[GraduationCampus]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GraduationCampusDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GraduationCampus.
    /// </summary>
    /// <returns>GraduationCampus</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GraduationCampusDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GraduationCampus entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
