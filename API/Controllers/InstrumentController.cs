
using APPLICATION.Dto.Instrument;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class InstrumentController : GenericController<Instrument, IInstrumentService, InstrumentDto, GetInstrumentDto>
{
    public InstrumentController(IMapper mapper, IInstrumentService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Instrument]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (Instrument) by id.
    /// </summary>
    /// <returns>Array[Instrument]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Instrument entry.
    /// </summary>
    /// <returns>Instrument</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(InstrumentDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of Instrument.
    /// </summary>
    /// <returns>Array[Instrument]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<InstrumentDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of Instrument.
    /// </summary>
    /// <returns>Instrument</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, InstrumentDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Instrument entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
