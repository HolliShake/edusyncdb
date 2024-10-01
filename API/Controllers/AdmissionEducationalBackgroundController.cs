
using APPLICATION.Dto.AdmissionEducationalBackground;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AdmissionEducationalBackgroundController : GenericController<AdmissionEducationalBackground, IAdmissionEducationalBackgroundService, AdmissionEducationalBackgroundDto, GetAdmissionEducationalBackgroundDto>
{
    public AdmissionEducationalBackgroundController(IMapper mapper, IAdmissionEducationalBackgroundService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all AdmissionEducationalBackgroundEduType.
    /// </summary>
    /// <returns>Array[Enum]</returns>
    [HttpGet("types/all")]
    public async Task<ActionResult> GetAllTypesAction()
    {
        return Ok((ICollection<object>)([
                new {
                    Id = AdmissionEducationalBackgroundEduType.Elementary,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.Elementary)
                },
                new {
                    Id = AdmissionEducationalBackgroundEduType.Secondary,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.Secondary)
                },
                new {
                    Id = AdmissionEducationalBackgroundEduType.Tertiary,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.Tertiary)
                },
                new {
                    Id = AdmissionEducationalBackgroundEduType.Vocational,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.Vocational)
                },
                new {
                    Id = AdmissionEducationalBackgroundEduType.PostGraduate,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.PostGraduate)
                },
                new {
                    Id = AdmissionEducationalBackgroundEduType.Masters,
                    Name = Enum.GetName(typeof(AdmissionEducationalBackgroundEduType), AdmissionEducationalBackgroundEduType.Masters)
                }
        ]));
    }

    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[AdmissionEducationalBackground]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (AdmissionEducationalBackground) by id.
    /// </summary>
    /// <returns>Array[AdmissionEducationalBackground]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new AdmissionEducationalBackground entry.
    /// </summary>
    /// <returns>AdmissionEducationalBackground</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(AdmissionEducationalBackgroundDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of AdmissionEducationalBackground.
    /// </summary>
    /// <returns>Array[AdmissionEducationalBackground]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<AdmissionEducationalBackgroundDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of AdmissionEducationalBackground.
    /// </summary>
    /// <returns>AdmissionEducationalBackground</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, AdmissionEducationalBackgroundDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single AdmissionEducationalBackground entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
