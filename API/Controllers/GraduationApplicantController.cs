using APPLICATION.Dto.GraduationApplicant;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.GraduateData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GraduationApplicantController : GenericController<GraduationApplicant, IGraduationApplicantService, GraduationApplicantDto, GetGraduationApplicantDto>
{
    public GraduationApplicantController(IMapper mapper, IGraduationApplicantService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GraduationApplicant]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GraduationApplicant) by id.
    /// </summary>
    /// <returns>Array[GraduationApplicant]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GraduationApplicant entry.
    /// </summary>
    /// <returns>GraduationApplicant</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GraduationApplicantDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GraduationApplicant.
    /// </summary>
    /// <returns>Array[GraduationApplicant]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GraduationApplicantDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GraduationApplicant.
    /// </summary>
    /// <returns>GraduationApplicant</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GraduationApplicantDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GraduationApplicant entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
