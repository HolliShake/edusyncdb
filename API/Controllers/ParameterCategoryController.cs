
using APPLICATION.Dto.ParameterCategory;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class ParameterCategoryController : GenericController<ParameterCategory, IParameterCategoryService, ParameterCategoryDto, GetParameterCategoryDto>
{
    public ParameterCategoryController(IMapper mapper, IParameterCategoryService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ParameterCategory]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ParameterCategory) by id.
    /// </summary>
    /// <returns>Array[ParameterCategory]></returns>
    [HttpGet("/Api/[controller]/{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ParameterCategory entry.
    /// </summary>
    /// <returns>ParameterCategory</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(ParameterCategoryDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of ParameterCategory.
    /// </summary>
    /// <returns>Array[ParameterCategory]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<ParameterCategoryDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of ParameterCategory.
    /// </summary>
    /// <returns>ParameterCategory</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ParameterCategoryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ParameterCategory entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
