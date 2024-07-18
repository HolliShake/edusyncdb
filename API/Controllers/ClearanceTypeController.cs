
using APPLICATION.Dto.ClearanceType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ClearanceTypeController : GenericController<ClearanceType, IClearanceTypeService, ClearanceTypeDto, GetClearanceTypeDto>
{
    public ClearanceTypeController(IMapper mapper, IClearanceTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ClearanceType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ClearanceType) by id.
    /// </summary>
    /// <returns>Array[ClearanceType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ClearanceType entry.
    /// </summary>
    /// <returns>ClearanceType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ClearanceTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ClearanceType.
    /// </summary>
    /// <returns>Array[ClearanceType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ClearanceTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ClearanceType.
    /// </summary>
    /// <returns>ClearanceType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ClearanceTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ClearanceType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
