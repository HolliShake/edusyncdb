
using APPLICATION.Dto.TableObject;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class TableObjectController : GenericController<TableObject, ITableObjectService, TableObjectDto, GetTableObjectDto>
{
    public TableObjectController(IMapper mapper, ITableObjectService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[TableObject]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get TableObject without parent.
    /// </summary>
    /// <returns>Array[TableObject]</returns>
    [HttpGet("IsParent/all")]
    public async Task<ActionResult> GetParentObject()
    {
        return Ok(await _repo.GetParentObject());
    }

    /// <summary>
    /// Get TableObject by AccountGroup id.
    /// </summary>
    /// <returns>Array[TableObject]</returns>
    [HttpGet("AccountGroup/{accountGroupId:int}")]
    public async Task<ActionResult> GetTableObjectByFundSourceId(int accountGroupId)
    {
        return Ok(await _repo.GetObjectByAccountGroupId(accountGroupId));
    }

    /// <summary>
    /// Get specific data (TableObject) by id.
    /// </summary>
    /// <returns>Array[TableObject]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new TableObject entry.
    /// </summary>
    /// <returns>TableObject</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(TableObjectDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of TableObject.
    /// </summary>
    /// <returns>Array[TableObject]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<TableObjectDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of TableObject.
    /// </summary>
    /// <returns>TableObject</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, TableObjectDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single TableObject entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
