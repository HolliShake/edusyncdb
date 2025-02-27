using APPLICATION.Dto.Building;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using API.Constant;
using APPLICATION.IService.CoreData;
using APPLICATION.IService.FileManagerData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class BuildingController : GenericController<Building, IBuildingService, BuildingDto, GetBuildingDto>
{
    private readonly ConfigurationManager _configurationManager;
    private readonly IFileManagerService _fileManagerService;

    public BuildingController(ConfigurationManager configurationManager, IMapper mapper, IBuildingService repo, IFileManagerService fileManagerService):base(mapper, repo)
    {
        _configurationManager = configurationManager;
        _fileManagerService = fileManagerService;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Building]</returns>
    /// <operationId>getAllBuilding</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get Building by Campus id.
    /// </summary>
    /// <returns>Array[Building]</returns>
    /// <operationId>getAllBuildingByCampusId</operationId>
    [HttpGet("Campus/{campusId:int}")]
    public async Task<ActionResult> GetBuildingByCampusId(int campusId)
    {
        return Ok(await _repo.GetBuildingByCampusId(campusId));
    }

    /// <summary>
    /// Get specific data (Building) by id.
    /// </summary>
    /// <returns>Array[Building]></returns>
    /// <operationId>getBuildingById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Creates new Building entry.
    /// </summary>
    /// <returns>Building</returns
    /// <operationId>createBuilding</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction([FromForm] BuildingDto item, [FromForm] List<IFormFile> files)
    {
        var model = _mapper.Map<Building>(item);

        var result = /**/
            await _repo.CreateAsync(model);

        if (result == null)
        {
            return BadRequest("Something went wrong!");
        }

        var data = _mapper.Map<GetBuildingDto>(model);

        var fileResult = await _fileManagerService.UploadMultipleFile(_configurationManager, FileScope.BuildingImagesScope, model.Id.ToString(), files);
        if (fileResult != null)
        {
            data.Images = fileResult.ToList()!;
        }

        return Ok(data);
    }

    /// <summary>
    /// Updates multiple property of Building.
    /// </summary>
    /// <returns>Building</returns>
    /// <operationId>updateBuilding</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, [FromForm] BuildingDto item, [FromForm] List<IFormFile> files)
    {
        var record = await _repo.GetAsync(id);

        if (record == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<Building>(record);

        var result = /**/
            await _repo.UpdateAsync(model);

        if (result == null)
        {
            return BadRequest("Something went wrong!");
        }

        var data = _mapper.Map<GetBuildingDto>(model);

        if (files.Count > 0)
        {
            var default_files = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.BuildingImagesScope, model.Id.ToString());

            var fileResult = await _fileManagerService.UploadMultipleFile(_configurationManager, FileScope.BuildingImagesScope, model.Id.ToString(), files);
            if (fileResult != null)
            {
                data.Images = fileResult.ToList()!;
                data.Images.AddRange(default_files);
            }
        }
        else
        {
            data.Images = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.BuildingImagesScope, model.Id.ToString());
        }

        return Ok(data);
    }

    /// <summary>
    /// Deletes single Building entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteBuilding</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
