
using APPLICATION.Dto.GeneratedSections;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class GeneratedSectionsController : GenericController<GeneratedSections, IGeneratedSectionsService, GeneratedSectionsDto, GetGeneratedSectionsDto>
{
    public GeneratedSectionsController(IMapper mapper, IGeneratedSectionsService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GeneratedSections]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get Generated Section by curriculum, cycle Id and yearLevel.
    /// </summary>
    /// <param name="curriculumId"></param>
    /// <param name="cycleId"></param>
    /// <param name="yearLevel"></param>
    /// <returns></returns>
    [HttpGet("Curriculum/{curriculumId:int}/Cycle/{cycleId:int}/YearLevel/{yearLevel:int}")]
    public async Task<ActionResult> GetGeneratedSection(int curriculumId, int cycleId, int yearLevel)
    {
        return Ok(await _repo.GetGeneratedSectionByCurriculumCycleIdAndYearLevel(curriculumId, cycleId, yearLevel));
    }

    /// <summary>
    /// Generate a section by the number of sections and the section group.
    /// </summary>
    /// <param name="numberOfSections"></param>
    /// <param name="sections"></param>
    /// <returns></returns>
    [HttpPost("generate/{numberOfSections:int}")]
    public async Task<ActionResult> GenerateSectionAction(int numberOfSections, GenerateSectionGroupDto sections)
    {
        var result = await _repo.GenerateSections(numberOfSections, sections);
        return (result != null)
            ? Ok(result)
            : BadRequest("Failed to generate a section");
    }

    /// <summary>
    /// Get specific data (GeneratedSections) by id.
    /// </summary>
    /// <returns>Array[GeneratedSections]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GeneratedSections entry.
    /// </summary>
    /// <returns>GeneratedSections</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GeneratedSectionsDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of GeneratedSections.
    /// </summary>
    /// <returns>Array[GeneratedSections]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GeneratedSectionsDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of GeneratedSections.
    /// </summary>
    /// <returns>GeneratedSections</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GeneratedSectionsDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single GeneratedSections entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
