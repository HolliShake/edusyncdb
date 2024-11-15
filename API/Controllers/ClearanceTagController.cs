
using APPLICATION.Dto.ClearanceTag;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using APPLICATION.Jwt;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ClearanceTagController : GenericController<ClearanceTag, IClearanceTagService, ClearanceTagDto, GetClearanceTagDto>
{
    protected readonly IJwtAuthManager _jwtAuthManager;
    public ClearanceTagController(
        IMapper mapper, 
        IClearanceTagService repo,
        IJwtAuthManager jwtAuthManager
    ):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/

    /// <summary>
    /// Get current user User Id
    /// </summary>
    /// <returns>string</returns>
    protected string GetUserId()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        return principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
    }

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
    public async Task<ActionResult> CreateAction(ClearanceTagByUserDto item)
    {
        return await GenericCreate(new ClearanceTagDto
        {
            IsExtensible = item.IsExtensible,
            IsOptional = item.IsOptional,
            IsSettled = false,
            Amount = item.Amount,
            Deadline = item.Deadline,
            ExtendedDeadline = item.ExtendedDeadline,
            RemindMeDate = item.RemindMeDate,
            SettlementInstruction = item.SettlementInstruction,
            Description = item.Description,
            ClearanceTypeId = item.ClearanceTypeId,
            UnclearedUserId = item.UnclearedUserId,
            DuWhoTagId = GetUserId()
        });
    }

    /// <summary>
    /// Mark as cleared.
    /// </summary>
    /// <param name="clearanceTagId"></param>
    /// <returns></returns>
    [HttpPatch("MarkAsCleared/{clearanceTagId:int}")]
    public async Task<ActionResult> MarkAsCleared(int clearanceTagId)
    {
        var result = await _repo.ChangedSettled(GetUserId(), clearanceTagId, true);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to mark as settled!");
    }

    /// <summary>
    /// Mark as uncleared.
    /// </summary>
    /// <param name="clearanceTagId"></param>
    /// <returns></returns>
    [HttpPatch("MarkAsUnCleared/{clearanceTagId:int}")]
    public async Task<ActionResult> MarkAsUnCleared(int clearanceTagId)
    {
        var result = await _repo.ChangedSettled(GetUserId(), clearanceTagId, false);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to mark as un-settled!");
    }

    /*
    /// <summary>
    /// Creates multiple instance of ClearanceTag.
    /// </summary>
    /// <returns>Array[ClearanceTag]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ClearanceTagDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of ClearanceTag.
    /// </summary>
    /// <returns>ClearanceTag</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ClearanceTagByUserDto item)
    {
        return await GenericUpdate(id, new ClearanceTagDto
        {
            IsExtensible = item.IsExtensible,
            IsOptional = item.IsOptional,
            IsSettled = false,
            Amount = item.Amount,
            Deadline = item.Deadline,
            ExtendedDeadline = item.ExtendedDeadline,
            RemindMeDate = item.RemindMeDate,
            SettlementInstruction = item.SettlementInstruction,
            Description = item.Description,
            ClearanceTypeId = item.ClearanceTypeId,
            UnclearedUserId = item.UnclearedUserId,
            DuWhoTagId = GetUserId()
        });
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
