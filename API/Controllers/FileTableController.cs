
using APPLICATION.Dto.FileTable;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class FileTableController : GenericController<FileTable, IFileTableService, FileTableDto, GetFileTableDto>
{
    public FileTableController(IMapper mapper, IFileTableService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
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
    /// Get specific data (FileTable) by id.
    /// </summary>
    /// <returns>Array[FileTable]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new FileTable entry.
    /// </summary>
    /// <returns>FileTable</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(FileTableDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of FileTable.
    /// </summary>
    /// <returns>Array[FileTable]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<FileTableDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of FileTable.
    /// </summary>
    /// <returns>FileTable</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, FileTableDto item)
    {
        return await GenericUpdate(id, item);
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
