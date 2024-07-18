
using APPLICATION.Dto.Parameter;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ParameterController : GenericController<Parameter, IParameterService, ParameterDto, GetParameterDto>
{
    public ParameterController(IMapper mapper, IParameterService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Parameter]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (Parameter) by id.
    /// </summary>
    /// <returns>Array[Parameter]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Parameter entry.
    /// </summary>
    /// <returns>Parameter</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ParameterDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Parameter.
    /// </summary>
    /// <returns>Array[Parameter]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ParameterDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Parameter.
    /// </summary>
    /// <returns>Parameter</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ParameterDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Parameter entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
