
using APPLICATION.Dto.Agency;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;
using APPLICATION.Jwt;
using API.Constant;
using APPLICATION.Dto.Building;
using INFRASTRUCTURE.Service.FileManagerData;
using APPLICATION.IService.FileManagerData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class AgencyController : GenericController<Agency, IAgencyService, AgencyDto, GetAgencyDto>
{
    private readonly ConfigurationManager _configurationManager;
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IFileManagerService _fileManagerService;

    public AgencyController(ConfigurationManager configurationManager, IMapper mapper, IAgencyService repo, IJwtAuthManager jwtAuthManager, IFileManagerService fileManagerService) :base(mapper, repo)
    {
        _configurationManager = configurationManager;
        _jwtAuthManager = jwtAuthManager;
        _fileManagerService = fileManagerService;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    /// <operationId>getAllAgency</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get specific data (Agency) by id.
    /// </summary>
    /// <returns>Array[Agency]></returns>
    /// <operationId>getAgencyById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new Agency entry.
    /// </summary>
    /// <returns>Agency</returns>
    /// <operationId>createAgency</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction([FromForm] AgencyDto item, [FromForm] List<IFormFile> files)
    {
        var model = _mapper.Map<Agency>(item);

        var result = /**/
            await _repo.CreateAsync(model);

        if (result == null)
        {
            return BadRequest("Something went wrong!");
        }

        var data = _mapper.Map<GetAgencyDto>(model);

        var fileResult = await _fileManagerService.UploadMultipleFile(_configurationManager, FileScope.AgencyLogoScope, model.Id.ToString(), files);
        if (fileResult != null)
        {
            data.Images = fileResult.ToList()!;
        }

        return Ok(data);
    }

    /// <summary>
    /// Creates multiple instance of Agency.
    /// </summary>
    /// <returns>Array[Agency]</returns>
    /// <operationId>insertAgency</operationId>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AgencyDto> items)
    {
        return await GenericCreateAll(items);
    }

    /// <summary>
    /// Updates multiple property of Agency.
    /// </summary>
    /// <returns>Agency</returns>
    /// <operationId>updateAgency</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AgencyDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Deletes single Agency entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteAgency</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
