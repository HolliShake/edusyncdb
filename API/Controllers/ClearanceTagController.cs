
using APPLICATION.Dto.ClearanceTag;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ClearanceTagController : GenericController<ClearanceTag, IClearanceTagService, ClearanceTagDto, GetClearanceTagDto>
{
    public ClearanceTagController(IMapper mapper, IClearanceTagService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ClearanceTag]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get ClearanceTag by ClearanceType id.
    /// </summary>
    /// <returns>Array[ClearanceTag]</returns>
    [HttpGet("ClearanceType/{clearanceTypeId:int}")]
    public async Task<ActionResult> GetClearanceTagByClearanceTypeId(int clearanceTypeId)
    {
        return Ok(await _repo.GetClearanceTagsByClearanceTypeId(clearanceTypeId));
    }

    /// <summary>
    /// Get specific data (ClearanceTag) by id.
    /// </summary>
    /// <returns>Array[ClearanceTag]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ClearanceTag entry.
    /// </summary>
    /// <returns>ClearanceTag</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ClearanceTagDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ClearanceTag.
    /// </summary>
    /// <returns>Array[ClearanceTag]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ClearanceTagDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ClearanceTag.
    /// </summary>
    /// <returns>ClearanceTag</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ClearanceTagDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ClearanceTag entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
