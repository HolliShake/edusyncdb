
using APPLICATION.Dto.VoucherApplied;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class VoucherAppliedController : GenericController<VoucherApplied, IVoucherAppliedService, VoucherAppliedDto, GetVoucherAppliedDto>
{
    public VoucherAppliedController(IMapper mapper, IVoucherAppliedService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[VoucherApplied]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (VoucherApplied) by id.
    /// </summary>
    /// <returns>Array[VoucherApplied]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new VoucherApplied entry.
    /// </summary>
    /// <returns>VoucherApplied</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(VoucherAppliedDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of VoucherApplied.
    /// </summary>
    /// <returns>Array[VoucherApplied]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<VoucherAppliedDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of VoucherApplied.
    /// </summary>
    /// <returns>VoucherApplied</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, VoucherAppliedDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single VoucherApplied entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
