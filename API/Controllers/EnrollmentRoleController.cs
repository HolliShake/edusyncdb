using APPLICATION.Dto.EnrollmentRole;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.EnrollmentData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentRoleController : GenericController<EnrollmentRole, IEnrollmentRoleService, EnrollmentRoleDto, GetEnrollmentRoleDto>
{
    public EnrollmentRoleController(IMapper mapper, IEnrollmentRoleService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentRole]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (EnrollmentRole) by id.
    /// </summary>
    /// <returns>Array[EnrollmentRole]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentRole entry.
    /// </summary>
    /// <returns>EnrollmentRole</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentRoleDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EnrollmentRole.
    /// </summary>
    /// <returns>Array[EnrollmentRole]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentRoleDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EnrollmentRole.
    /// </summary>
    /// <returns>EnrollmentRole</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentRoleDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentRole entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
