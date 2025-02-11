
using APPLICATION.Dto.College;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class CollegeController : GenericController<College, ICollegeService, CollegeDto, GetCollegeDto>
{
    public CollegeController(IMapper mapper, ICollegeService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[College]</returns>
    /// <operationId>getAllCollege</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get College by CampusId.
    /// </summary>
    /// <returns>Array[College]</returns>
    /// <operationId>getCollegeByCampusId</operationId>
    [HttpGet("Campus/{campusId:int}")]
    public async Task<ActionResult> GetCollegeByCampusId(int campusId)
    {
        return Ok(await _repo.GetCollegesByCampusId(campusId));
    }

    /// <summary>
    /// Get specific data (College) by id.
    /// </summary>
    /// <returns>Array[College]></returns>
    /// <operationId>getCollegeById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new College entry.
    /// </summary>
    /// <returns>College</returns>
    /// <operationId>createCollege</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(CollegeDto item)
    {
        return await GenericCreate(item);
    }

    /*
    /// <summary>
    /// Creates multiple instance of College.
    /// </summary>
    /// <returns>Array[College]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CollegeDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of College.
    /// </summary>
    /// <returns>College</returns>
    /// <operationId>updateCollege</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CollegeDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single College entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteCollege</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
