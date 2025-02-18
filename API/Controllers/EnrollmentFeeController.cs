using APPLICATION.Dto.EnrollmentFee;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentFeeController : GenericController<EnrollmentFee, IEnrollmentFeeService, EnrollmentFeeDto, GetEnrollmentFeeDto>
{
    public EnrollmentFeeController(IMapper mapper, IEnrollmentFeeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentFee]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get EnrollmentFee by TableObject id.
    /// </summary>
    /// <returns>Array[EnrollmentFee]</returns>
    [HttpGet("Object/{objectId:int}")]
    public async Task<ActionResult> GetEnrollmentFeeByObjectId(int objectId)
    {
        return Ok(await _repo.GetEnrollmentFeesByObjectId(objectId));
    }

    /// <summary>
    /// Get EnrollmentFee by FundSource id.
    /// </summary>
    /// <returns>Array[EnrollmentFee]</returns>
    [HttpGet("FundSource/{fundSourceId:int}")]
    public async Task<ActionResult> GetEnrollmentFeeByFundSourceId(int fundSourceId)
    {
        return Ok(await _repo.GetEnrollmentFeesByFundSourceId(fundSourceId));
    }

    /// <summary>
    /// Get specific data (EnrollmentFee) by id.
    /// </summary>
    /// <returns>Array[EnrollmentFee]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentFee entry.
    /// </summary>
    /// <returns>EnrollmentFee</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentFeeDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EnrollmentFee.
    /// </summary>
    /// <returns>Array[EnrollmentFee]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentFeeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EnrollmentFee.
    /// </summary>
    /// <returns>EnrollmentFee</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentFeeDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentFee entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
