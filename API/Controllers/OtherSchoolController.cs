using APPLICATION.Dto.OtherSchool;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class OtherSchoolController : GenericController<OtherSchool, IOtherSchoolService, OtherSchoolDto, GetOtherSchoolDto>
{
    public OtherSchoolController(IMapper mapper, IOtherSchoolService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[OtherSchool]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (OtherSchool) by id.
    /// </summary>
    /// <returns>Array[OtherSchool]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new OtherSchool entry.
    /// </summary>
    /// <returns>OtherSchool</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(OtherSchoolDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of OtherSchool.
    /// </summary>
    /// <returns>Array[OtherSchool]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<OtherSchoolDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of OtherSchool.
    /// </summary>
    /// <returns>OtherSchool</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, OtherSchoolDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single OtherSchool entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
