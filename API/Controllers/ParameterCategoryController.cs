using APPLICATION.Dto.ParameterCategory;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.SurveyFormData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
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
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (ParameterCategory) by id.
    /// </summary>
    /// <returns>Array[ParameterCategory]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new ParameterCategory entry.
    /// </summary>
    /// <returns>ParameterCategory</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(ParameterCategoryDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of ParameterCategory.
    /// </summary>
    /// <returns>Array[ParameterCategory]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<ParameterCategoryDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of ParameterCategory.
    /// </summary>
    /// <returns>ParameterCategory</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, ParameterCategoryDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single ParameterCategory entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
