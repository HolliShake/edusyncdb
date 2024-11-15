
using APPLICATION.Dto.GradeBookScore;
using APPLICATION.IService;
using DOMAIN.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
[Casl("SuperAdmin:all")]
public class GradeBookScoreController : GenericController<GradeBookScore, IGradeBookScoreService, GradeBookScoreDto, GetGradeBookScoreDto>
{
    public GradeBookScoreController(IMapper mapper, IGradeBookScoreService repo):base(mapper, repo)
    {
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns>Array[GradeBookScore]</returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllAction()
    {
        return await GenericGetAll();
    }

    /// <summary>
    /// Get all enrollment score by gradebook item detail id.
    /// </summary>
    /// <param name="gradeBookItemDetailId"></param>
    /// <returns></returns>
    [HttpGet("GradeBookItemDetail/{gradeBookItemDetailId:int}")]
    public async Task<ActionResult> GetAllEnrollmentStudentGradeBookScoreByGradeBookItemDetailId(int gradeBookItemDetailId)
    {
        return Ok(await _repo.GetEnrolledStudentWithOrWithoutScoreByGradeBookItemDetailsId(gradeBookItemDetailId));
    }

    /// <summary>
    /// Get GradeBook overall Information by Schedule and Student Id.
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <param name="studentId"></param>
    /// <returns></returns>
    [HttpGet("GradeBookInformation/Schedule/{scheduleId:int}/Student/{studentId:int}")]
    public async Task<ActionResult> GetStudentGradeBookInformationByScheduleAndStudentId(int scheduleId, int studentId)
    {
        return Ok(await _repo.GetStudentGradeBookInformationByScheduleAndStudentId(scheduleId, studentId));
    }

    /// <summary>
    /// Get specific data (GradeBookScore) by id.
    /// </summary>
    /// <returns>Array[GradeBookScore]></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAction(int id)
    {
        return await GenericGet(id);
    }
    
    /// <summary>
    /// Creates new GradeBookScore entry.
    /// </summary>
    /// <returns>GradeBookScore</returns>
    [HttpPost("create")]
    public async Task<ActionResult> CreateAction(GradeBookScoreDto item)
    {
        return await GenericCreate(item);
    }

    /// <summary>
    /// Give multiple score both support create and update
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost("give/score/multiple")]
    public async Task<ActionResult> GiveScoreMultipleAction(GiveGradeBookScoreGroupDto item)
    {
        return Ok(await _repo.GiveScoreMultiple(item));
    }
    
    /*
    /// <summary>
    /// Creates multiple instance of GradeBookScore.
    /// </summary>
    /// <returns>Array[GradeBookScore]</returns>
    [HttpPost("insert")]
    public async Task<ActionResult> CreateAllAction(List<GradeBookScoreDto> items)
    {
        return await GenericCreateAll(items);
    }
    */
    
    /// <summary>
    /// Updates multiple property of GradeBookScore.
    /// </summary>
    /// <returns>GradeBookScore</returns>
    [HttpPut("update/{id:int}")]
    public async Task<ActionResult> UpdateAction(int id, GradeBookScoreDto item)
    {
        return await GenericUpdate(id, item);
    }

    /// <summary>
    /// Updates score property of GradeBookScore.
    /// </summary>
    /// <returns>GradeBookScore</returns>
    [HttpPut("update/Enrollment/{enrollmentId:int}/GradeBookItemDetail/{gradeBookItemDetailId:int}/score/{id:int}")]
    public async Task<ActionResult> UpdateScoreAction(int enrollmentId, int gradeBookItemDetailId, int id, GradeBookScoreOnlyDto item)
    {

        if (!(await _repo.HasAnyScoreByEnrollmentAndGradeBookItemDetailsId(enrollmentId, gradeBookItemDetailId)))
        {
            // Create Mode
            return await GenericCreate(new GradeBookScoreDto
            {
                EnrollmentId = enrollmentId,
                GradeBookItemDetailId = gradeBookItemDetailId,
                Score = item.Score,
                Remarks = ""
            });
        }

        var current = await _repo.DefaultScoreByEnrollmentAndGradeBookItemDetailsIdOrNone(enrollmentId, gradeBookItemDetailId, id);
        if (current == null)
        {
            return NotFound("Score not found");
        }

        current.Score = item.Score;
        return await GenericUpdate(current.Id, new GradeBookScoreDto
        {
            EnrollmentId = current.EnrollmentId,
            GradeBookItemDetailId = current.GradeBookItemDetailId,
            Score = current.Score,
            Remarks = current.Remarks
        });
    }

    /// <summary>
    /// Deletes single GradeBookScore entry.
    /// </summary>
    /// <returns>Null</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> DeleteAction(int id)
    {
        return await GenericDelete(id);
    }
}
