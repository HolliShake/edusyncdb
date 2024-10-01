
using APPLICATION.Dto.EnrollmentPayment;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class EnrollmentPaymentController : GenericController<EnrollmentPayment, IEnrollmentPaymentService, EnrollmentPaymentDto, GetEnrollmentPaymentDto>
{
    public EnrollmentPaymentController(IMapper mapper, IEnrollmentPaymentService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[EnrollmentPayment]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /*
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <returns>Array[EnrollmentPayment]</returns>
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    */
    
    /// <summary>
    /// Get specific data (EnrollmentPayment) by id.
    /// </summary>
    /// <returns>Array[EnrollmentPayment]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new EnrollmentPayment entry.
    /// </summary>
    /// <returns>EnrollmentPayment</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(EnrollmentPaymentDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of EnrollmentPayment.
    /// </summary>
    /// <returns>Array[EnrollmentPayment]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<EnrollmentPaymentDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of EnrollmentPayment.
    /// </summary>
    /// <returns>EnrollmentPayment</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, EnrollmentPaymentDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single EnrollmentPayment entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
