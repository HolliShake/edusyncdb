
using APPLICATION.Dto.GraduationCampus;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
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
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GraduationCampus) by id.
    /// </summary>
    /// <returns>Array[GraduationCampus]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GraduationCampus entry.
    /// </summary>
    /// <returns>GraduationCampus</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(GraduationCampusDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of GraduationCampus.
    /// </summary>
    /// <returns>Array[GraduationCampus]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<GraduationCampusDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of GraduationCampus.
    /// </summary>
    /// <returns>GraduationCampus</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GraduationCampusDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GraduationCampus entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
