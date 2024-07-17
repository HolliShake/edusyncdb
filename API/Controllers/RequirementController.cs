
using APPLICATION.Dto.Requirement;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class RequirementController : GenericController<Requirement, IRequirementService, RequirementDto, GetRequirementDto>
{
    public RequirementController(IMapper mapper, IRequirementService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Requirement]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get active requirement.
    /// </summary>
    /// <returns>Array[Requirement]</returns>
    [HttpGet("/Api/[controller]/Active")]
    public async Task<ActionResult> GetActiveRequirement()
    {
        return Ok(_mapper.Map<ICollection<GetRequirementDto>>(await _repo.GetActiveRequirement()));
    }
    
    /// <summary>
    /// Get specific data (Requirement) by id.
    /// </summary>
    /// <returns>Array[Requirement]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new Requirement entry.
    /// </summary>
    /// <returns>Requirement</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(RequirementDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of Requirement.
    /// </summary>
    /// <returns>Array[Requirement]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<RequirementDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of Requirement.
    /// </summary>
    /// <returns>Requirement</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, RequirementDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single Requirement entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
