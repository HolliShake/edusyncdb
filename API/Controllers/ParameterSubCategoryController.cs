
using APPLICATION.Dto.ParameterSubCategory;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class ParameterSubCategoryController : GenericController<ParameterSubCategory, IParameterSubCategoryService, ParameterSubCategoryDto, GetParameterSubCategoryDto>
{
    public ParameterSubCategoryController(IMapper mapper, IParameterSubCategoryService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[ParameterSubCategory]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ParameterSubCategory) by id.
    /// </summary>
    /// <returns>Array[ParameterSubCategory]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ParameterSubCategory entry.
    /// </summary>
    /// <returns>ParameterSubCategory</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ParameterSubCategoryDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ParameterSubCategory.
    /// </summary>
    /// <returns>Array[ParameterSubCategory]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ParameterSubCategoryDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ParameterSubCategory.
    /// </summary>
    /// <returns>ParameterSubCategory</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ParameterSubCategoryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ParameterSubCategory entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
