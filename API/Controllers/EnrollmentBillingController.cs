
using APPLICATION.Dto.EnrollmentBilling;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentBillingController : GenericController<EnrollmentBilling, IEnrollmentBillingService, EnrollmentBillingDto, GetEnrollmentBillingDto>
{
    public EnrollmentBillingController(IMapper mapper, IEnrollmentBillingService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get EnrollmentBilling by Enrollment id.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpGet("Enrollment/{enrollmentId:int}")]
    public async Task<ActionResult> GetEnrollmentBillingByEnrollmentId(int enrollmentId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _repo.GetEnrollmentBillingsByEnrollmentId(enrollmentId)));
    }

    /// <summary>
    /// Get EnrollmentBilling by EnrollmentFee id.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpGet("EnrollmentFee/{enrollmentFeeId:int}")]
    public async Task<ActionResult> GetEnrollmentBillingByEnrollmenFeetId(int enrollmentFeeId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _repo.GetEnrollmentBillingsByEnrollmentFeeId(enrollmentFeeId)));
    }

    /// <summary>
    /// Get EnrollmentBilling by Cycle id.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpGet("Cycle/{cycleId:int}")]
    public async Task<ActionResult> GetEnrollmentBillingByCycleId(int cycleId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _repo.GetEnrollmentBillingsByCycleId(cycleId)));
    }

    /// <summary>
    /// Get EnrollmentBilling by Voucher id.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpGet("Voucher/{voucherId:int}")]
    public async Task<ActionResult> GetEnrollmentBillingByVoucherId(int voucherId)
    {
        return Ok(_mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _repo.GetEnrollmentBillingsByVoucherId(voucherId)));
    }

    /// <summary>
    /// Get specific data (EnrollmentBilling) by id.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentBilling entry.
    /// </summary>
    /// <returns>EnrollmentBilling</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentBillingDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of EnrollmentBilling.
    /// </summary>
    /// <returns>Array[EnrollmentBilling]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentBillingDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of EnrollmentBilling.
    /// </summary>
    /// <returns>EnrollmentBilling</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentBillingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentBilling entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
