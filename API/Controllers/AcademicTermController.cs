using APPLICATION.Dto.AcademicTerm;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AcademicTermController : GenericController<AcademicTerm, IAcademicTermService, AcademicTermDto, GetAcademicTermDto>
{
    public AcademicTermController(IMapper mapper, IAcademicTermService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AcademicTerm]</returns>
    /// <operationId>getAllAcademicTerm</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (AcademicTerm) by id.
    /// </summary>
    /// <returns>Array[AcademicTerm]></returns>
    /// <operationId>getAcademicTermById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new AcademicTerm entry.
    /// </summary>
    /// <returns>AcademicTerm</returns>
    /// <operationId>createAcademicTerm</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AcademicTermDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of AcademicTerm.
    /// </summary>
    /// <returns>Array[AcademicTerm]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AcademicTermDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of AcademicTerm.
    /// </summary>
    /// <returns>AcademicTerm</returns>
    /// <operationId>updateAcademicTerm</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AcademicTermDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single AcademicTerm entry.
    /// </summary>
    /// <returns>Null</returns
    /// <operationId>deleteAcademicTerm</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
