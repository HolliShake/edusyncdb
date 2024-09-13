
using APPLICATION.Dto.EnrollmentGrade;
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
public class EnrollmentGradeController : GenericController<EnrollmentGrade, IEnrollmentGradeService, EnrollmentGradeDto, GetEnrollmentGradeDto>
{
    private readonly IJwtAuthManager _jwtAuthManager;
    public EnrollmentGradeController(IMapper mapper, IEnrollmentGradeService repo, IJwtAuthManager jwtAuthManager):base(mapper, repo)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    
    /// <summary>
    /// Get specific data (EnrollmentGrade) by id.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentGrade entry.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentGradeDto item)
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        item.EncodedByUserId = (item.EncodedByUserId.Length > 0) ? item.EncodedByUserId : userId;
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EnrollmentGrade.
    /// </summary>
    /// <returns>Array[EnrollmentGrade]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentGradeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EnrollmentGrade.
    /// </summary>
    /// <returns>EnrollmentGrade</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentGradeDto item)
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        item.EncodedByUserId = (item.EncodedByUserId.Length > 0) ? item.EncodedByUserId : userId;
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentGrade entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
