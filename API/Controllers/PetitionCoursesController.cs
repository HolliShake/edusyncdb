using APPLICATION.Dto.PetitionCourses;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using APPLICATION.IService.CoreData;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class PetitionCoursesController : GenericController<PetitionCourses, IPetitionCoursesService, PetitionCoursesDto, GetPetitionCoursesDto>
{
    public PetitionCoursesController(IMapper mapper, IPetitionCoursesService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[PetitionCourses]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }
    
    /// <summary>
    /// Get specific data (PetitionCourses) by id.
    /// </summary>
    /// <returns>Array[PetitionCourses]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new PetitionCourses entry.
    /// </summary>
    /// <returns>PetitionCourses</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(PetitionCoursesDto item)
    {
        return await GenericCreate(item);
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of PetitionCourses.
    /// </summary>
    /// <returns>Array[PetitionCourses]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<PetitionCoursesDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of PetitionCourses.
    /// </summary>
    /// <returns>PetitionCourses</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, PetitionCoursesDto item)
    {
        return await GenericUpdate(id, item);
    }
    
    /// <summary>
    /// Deletes single PetitionCourses entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
