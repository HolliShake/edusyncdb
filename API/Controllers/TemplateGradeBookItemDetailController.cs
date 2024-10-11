
using APPLICATION.Dto.TemplateGradeBookItemDetail;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TemplateGradeBookItemDetailController : GenericController<TemplateGradeBookItemDetail, ITemplateGradeBookItemDetailService, TemplateGradeBookItemDetailDto, GetTemplateGradeBookItemDetailDto>
{
    public TemplateGradeBookItemDetailController(IMapper mapper, ITemplateGradeBookItemDetailService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItemDetail]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (TemplateGradeBookItemDetail) by id.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItemDetail]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new TemplateGradeBookItemDetail entry.
    /// </summary>
    /// <returns>TemplateGradeBookItemDetail</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(TemplateGradeBookItemDetailDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of TemplateGradeBookItemDetail.
    /// </summary>
    /// <returns>Array[TemplateGradeBookItemDetail]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<TemplateGradeBookItemDetailDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of TemplateGradeBookItemDetail.
    /// </summary>
    /// <returns>TemplateGradeBookItemDetail</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, TemplateGradeBookItemDetailDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single TemplateGradeBookItemDetail entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
