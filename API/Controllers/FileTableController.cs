
using APPLICATION.Dto.FileTable;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using API.Constant;
using APPLICATION.IService.FileManagerData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]

//FileTable, GetFileTableDto
public class FileTableController : GenericController<FileTable, IFileTableService, FileTableDto, GetFileTableDto>
{
    private readonly ConfigurationManager _configurationManager;
    private readonly IFileManagerService _fileManagerService;
    public FileTableController(ConfigurationManager configurationManager, IMapper mapper, IFileTableService repo, IFileManagerService fileManagerService):base(mapper, repo)
    {
        _configurationManager = configurationManager;
        _fileManagerService   = fileManagerService;
    }

    /****************** ACTION ROUTES ******************/
    
    /// <summary>
    /// Get all valid scopes
    /// </summary>
    /// <returns></returns>
    [HttpGet("Scopes")]
    public ActionResult GetAllValidScope()
    {
        List<string> scopes = [
            FileScope.UserProfileScope   ,   
            FileScope.CampusImagesScope  ,
            FileScope.BuildingImagesScope,
        ];
        return Ok(scopes);
    }

    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[FileTable]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Upload file to server.
    /// </summary>
    /// <param name="scope"></param>
    /// <param name="referenceId"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost("upload/{scope}/{referenceId}")]
    public async Task<ActionResult> UploadAction(string scope, string referenceId, IFormFile file)
    {
        if (file.Length <= 0)
        {
            return BadRequest("File is empty!");
        }
        var upload = await _fileManagerService.UploadFile(_configurationManager, scope, referenceId, file);
        return (upload != null)
            ? Ok(upload)
            : BadRequest();
    }
    
    /// <summary>
    /// Get specific data (FileTable) by id.
    /// </summary>
    /// <returns>Array[FileTable]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }

    /// <summary>
    /// Get Files by scope and referenceId
    /// </summary>
    /// <param name="scope"></param>
    /// <param name="refId"></param>
    /// <returns></returns>
    [HttpGet("{scope}/{refId}")]
    public async Task<ActionResult> GetByReferenceId(string scope, string refId)
    {
        return Ok(await _fileManagerService.GetFileByScopeAndRefereneId(scope, refId));
    }
    
    /*
    /// <summary>
    /// Creates new FileTable entry.
    /// </summary>
    /// <returns>FileTable</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(FileTableDto item)
    {
        return await GenericCreate(item);
    }
    */
    
    /*
    /// <summary>
    /// Creates multiple instance of FileTable.
    /// </summary>
    /// <returns>Array[FileTable]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<FileTableDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of FileTable.
    /// </summary>
    /// <operationId>updateFileTable</operationId>
    /// <returns>FileTable</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, IFormFile file)
    {
        if (file.Length <= 0)
        {
            return BadRequest("File is empty!");
        }

        var upload = await _fileManagerService.UpdateFile(_configurationManager, id, file);
        
        return (upload != null)
            ? Ok(upload)
            : BadRequest("Failed to update file");
    }
    
    /// <summary>
    /// Deletes single FileTable entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
