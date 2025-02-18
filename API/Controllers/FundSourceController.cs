using APPLICATION.Dto.FundSource;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.AccountingData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class FundSourceController : GenericController<FundSource, IFundSourceService, FundSourceDto, GetFundSourceDto>
{
    public FundSourceController(IMapper mapper, IFundSourceService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[FundSource]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (FundSource) by id.
    /// </summary>
    /// <returns>Array[FundSource]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new FundSource entry.
    /// </summary>
    /// <returns>FundSource</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(FundSourceDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of FundSource.
    /// </summary>
    /// <returns>Array[FundSource]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<FundSourceDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of FundSource.
    /// </summary>
    /// <returns>FundSource</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, FundSourceDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single FundSource entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
