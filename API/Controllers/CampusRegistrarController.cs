
using APPLICATION.Dto.CampusRegistrar;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.IService.DesignationData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CampusRegistrarController : GenericController<CampusRegistrar, ICampusRegistrarService, CampusRegistrarDto, GetCampusRegistrarDto>
{
    public CampusRegistrarController(IMapper mapper, ICampusRegistrarService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CampusRegistrar]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (CampusRegistrar) by id.
    /// </summary>
    /// <returns>Array[CampusRegistrar]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new CampusRegistrar entry.
    /// </summary>
    /// <returns>CampusRegistrar</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CampusRegistrarDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of CampusRegistrar.
    /// </summary>
    /// <returns>Array[CampusRegistrar]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CampusRegistrarDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of CampusRegistrar.
    /// </summary>
    /// <returns>CampusRegistrar</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CampusRegistrarDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CampusRegistrar entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
