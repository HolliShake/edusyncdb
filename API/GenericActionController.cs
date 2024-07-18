using APPLICATION.IService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API;

public class
    GenericActionController<TModel, IServiceProvider, ItemDto, GetDto> : GenericController<TModel, IServiceProvider,
    ItemDto, GetDto> where IServiceProvider : IGenericService<TModel, GetDto>
{
    public GenericActionController(IMapper mapper, IServiceProvider repo):base(mapper, repo)
    {
       
    }
    
    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>Array[TItem]</returns>
    [Casl("Admin:read" )]
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get 1st to n (where n := size(parameter)) data.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>Array[Item]</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpGet("chunk/{size:int}")]
    public async Task<ActionResult> GetByChunk(int size)
    {
        return await GenericGetByChunk(size);
    }
    
    /// <summary>
    /// Get specific data by id.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>Array[T]></returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new item.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>TItem</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ItemDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple item.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>Array[TItem]</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ItemDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates single property of an item.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>TItem</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpPatch("patch/{id:int}")]
    public async Task<ActionResult> PatchAction(int id, ItemDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Updates multiple property of an item.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>TItem</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ItemDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes an item.
    /// </summary>
    /// <remarks>(From GenericController)</remarks>
    /// <returns>Null</returns>
    [Casl("Auth:read", "Admin:read" )]
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}