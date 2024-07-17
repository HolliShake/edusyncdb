
using APPLICATION.Dto.CourseCrediting;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Casl("Admin:all")]
public class CourseCreditingController : GenericController<CourseCrediting, ICourseCreditingService, CourseCreditingDto, GetCourseCreditingDto>
{
    public CourseCreditingController(IMapper mapper, ICourseCreditingService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[CourseCrediting]</returns>
    [HttpGet("/Api/[controller]/all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Creates new CourseCrediting entry.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPost("/Api/[controller]/create")]
    public async Task<ActionResult> CreateAction(CourseCreditingDto item)
    {
        return await GenericCreate(item);
    }
    
    /// <summary>
    /// Creates multiple instance of CourseCrediting.
    /// </summary>
    /// <returns>Array[CourseCrediting]</returns>
    [HttpPost("/Api/[controller]/insert")]
    public async Task<ActionResult> CreateAllAction(List<CourseCreditingDto> items)
    {
        return await GenericCreateAll(items);
    }
    
    /// <summary>
    /// Updates multiple property of CourseCrediting.
    /// </summary>
    /// <returns>CourseCrediting</returns>
    [HttpPut("/Api/[controller]/update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, CourseCreditingDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single CourseCrediting entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("/Api/[controller]/delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
