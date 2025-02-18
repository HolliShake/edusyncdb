using APPLICATION.Dto.Campus;
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
public class CampusController : GenericController<Campus, ICampusService, CampusDto, GetCampusDto>
{
    private readonly ConfigurationManager _configurationManager;
    private readonly IFileManagerService _fileManagerService;
    public CampusController(ConfigurationManager configurationManager, IFileManagerService fileManagerService, IMapper mapper, ICampusService repo):base(mapper, repo)
    {
        _configurationManager = configurationManager;
        _fileManagerService = fileManagerService;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    /// <operationId>getAllCampus</operationId>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        var items = await _repo.GetAllAsync();
        var data = _mapper.Map<ICollection<GetCampusDto>>(items);
        foreach (var item in data)
        {
            item.Images = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.CampusImagesScope, item.Id.ToString());
        }
        return Ok(data);
    }

    /// <summary>
    /// Get all campus by agency id.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    /// <operationId>getAllCampusByAgencyId</operationId>
    [HttpGet("Agency/{agencyId:int}")]
    public async Task<ActionResult> GetCampusesByAgencyId(int agencyId)
    {
        var items = await _repo.GetCampusByAgendyId(agencyId);
        foreach (var item in items)
        {
            item.Images = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.CampusImagesScope, item.Id.ToString());
        }
        return Ok(items);
    }

    /// <summary>
    /// Get specific data (Campus) by id.
    /// </summary>
    /// <returns>Array[Campus]></returns>
    /// <operationId>getCampusById</operationId>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        var result = await _repo.GetAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        var data = _mapper.Map<GetCampusDto>(result);
        data.Images = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.CampusImagesScope, data.Id.ToString());

        return Ok(data);
    }

    /// <summary>
    /// Creates new Campus entry.
    /// </summary>
    /// <returns>Campus</returns>
    /// <operationId>createCampus</operationId>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction([FromForm] CampusDto item, [FromForm] List<IFormFile> files)
    {
        var model = _mapper.Map<Campus>(item);
        var result = /**/
            await _repo.CreateAsync(model);

        if (result == null)
        {
            goto end;
        }

        var fileResult = await _fileManagerService.UploadMultipleFile(_configurationManager, FileScope.CampusImagesScope, model.Id.ToString(), files);
        if (fileResult != null)
        {
           result.Images = fileResult.ToList()!;
        }

        end:;
        return (result != null)
            ? Ok(result)
            : BadRequest("Something went wrong!");
    }

    /*
    /// <summary>
    /// Creates multiple instance of Campus.
    /// </summary>
    /// <returns>Array[Campus]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<CampusDto> items)
    {
        return await GenericCreateAll(items);
    }
    */

    /// <summary>
    /// Updates multiple property of Campus.
    /// </summary>
    /// <returns>Campus</returns>
    /// <operationId>updateCampus</operationId>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, [FromForm] CampusDto item, [FromForm] List<IFormFile> files)
    {
        var record = await _repo.GetAsync(id);

        if (record == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<Campus>(record);

        var result = /**/
            await _repo.UpdateAsync(model);

        if (result == null)
        {
            goto end;
        }

        if (files.Count > 0)
        {
            var default_files = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.CampusImagesScope, model.Id.ToString());

            var fileResult = await _fileManagerService.UploadMultipleFile(_configurationManager, FileScope.CampusImagesScope, model.Id.ToString(), files);
            if (fileResult != null)
            {
                result.Images = fileResult.ToList()!;
                result.Images.AddRange(default_files);
            }
        }
        else
        {
            result.Images = await _fileManagerService.GetFileByScopeAndReferenceId(FileScope.CampusImagesScope, model.Id.ToString());
        }

        end:;
        return (result != null)
            ? Ok(result)
            : BadRequest("Something went wrong!");
    }

    /// <summary>
    /// Deletes single Campus entry.
    /// </summary>
    /// <returns>Null</returns>
    /// <operationId>deleteCampus</operationId>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
