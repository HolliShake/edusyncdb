
using APPLICATION.Dto.GradeInput;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class GradeInputController : GenericController<GradeInput, IGradeInputService, GradeInputDto, GetGradeInputDto>
{
    public GradeInputController(IMapper mapper, IGradeInputService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeInput]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (GradeInput) by id.
    /// </summary>
    /// <returns>Array[GradeInput]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeInput entry.
    /// </summary>
    /// <returns>GradeInput</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(GradeInputDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of GradeInput.
    /// </summary>
    /// <returns>Array[GradeInput]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeInputDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of GradeInput.
    /// </summary>
    /// <returns>GradeInput</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeInputDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GradeInput entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
