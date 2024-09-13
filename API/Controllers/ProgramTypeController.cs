
using APPLICATION.Dto.ProgramType;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ProgramTypeController : GenericController<ProgramType, IProgramTypeService, ProgramTypeDto, GetProgramTypeDto>
{
    public ProgramTypeController(IMapper mapper, IProgramTypeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ProgramType]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
  
    /// <summary>
    /// Get specific data (ProgramType) by id.
    /// </summary>
    /// <returns>Array[ProgramType]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ProgramType entry.
    /// </summary>
    /// <returns>ProgramType</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ProgramTypeDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ProgramType.
    /// </summary>
    /// <returns>Array[ProgramType]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ProgramTypeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ProgramType.
    /// </summary>
    /// <returns>ProgramType</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ProgramTypeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ProgramType entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
