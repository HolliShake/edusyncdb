
using APPLICATION.Dto.Voucher;
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
public class VoucherController : GenericController<Voucher, IVoucherService, VoucherDto, GetVoucherDto>
{
    public VoucherController(IMapper mapper, IVoucherService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Voucher]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (Voucher) by id.
    /// </summary>
    /// <returns>Array[Voucher]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Voucher entry.
    /// </summary>
    /// <returns>Voucher</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(VoucherDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of Voucher.
    /// </summary>
    /// <returns>Array[Voucher]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<VoucherDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of Voucher.
    /// </summary>
    /// <returns>Voucher</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, VoucherDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Voucher entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
