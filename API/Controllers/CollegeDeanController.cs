
using APPLICATION.Dto.CollegeDean;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Dto.CollegeDean;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CollegeDeanController : GenericController<CollegeDean, ICollegeDeanService, CollegeDeanDto, GetCollegeDeanDto>
{
    public CollegeDeanController(IMapper mapper, ICollegeDeanService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CollegeDean]</returns>
    /// <operationId>getAllCollegeDean</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (CollegeDean) by id.
    /// </summary>
    /// <returns>Array[CollegeDean]></returns>
    /// <operationId>getCollegeDeanById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new CollegeDean entry.
    /// </summary>
    /// <returns>CollegeDean</returns>
    /// <operationId>createCollegeDean</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CollegeDeanDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Creates multiple instance of CollegeDean.
    /// </summary>
    /// <returns>Array[CollegeDean]</returns>
    /// <operationId>insertCollegeDean</operationId>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CollegeDeanDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Updates multiple property of CollegeDean.
    /// </summary>
    /// <returns>CollegeDean</returns>
    /// <operationId>updateCollegeDean</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CollegeDeanDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single CollegeDean entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteCollegeDean</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
