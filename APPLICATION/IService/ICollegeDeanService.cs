
using APPLICATION.Dto.College;
using APPLICATION.Dto.CollegeDean;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICollegeDeanService:IGenericService<CollegeDean, GetCollegeDeanDto>
{
    public Task<bool> IsCollegeDean(string userId);
    public Task<GetCollegeDto> GetCollegeByUserId(string userId);
    public Task<object> GetAllProgramChairByCollegeId(int collegeId);
    public Task<object> GetStudentByCollegeId(int collegeId);
    public Task<object> GetTeacherByCollegeId(int collegeId);
    public Task<object> GetStudentsWithUnClearedStatus(int collegeId);
    public Task<object> GetCurriculumPerAcademicProgramByCollegeId(int collegeId);
}