
using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.AcademicProgramChair;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAcademicProgramChairService:IGenericService<AcademicProgramChair, GetAcademicProgramChairDto>
{
    public Task<bool> IsProgramChair(string userId);
    public Task<GetAcademicProgramDto?> GetAcademicProgramByUserId(string userId);
    public Task<object> GetStudentsByAcademicProgram(int academicProgramId, int limit);
    public Task<object> GetTeachersByAcademicProgram(int academicProgramId, int limit);
    public Task<object> GetActiveCurriculumCoursesByAcademicProgram(int academicProgramId);
    public Task<object> GetCurriculumsByAcademicProgram(int academicProgramId);
    public Task<object> GetActiveCurriculumSectionsByAcademicProgram(int academicProgramId);
    public Task<object> GetActiveCurriculumSectionsByAcademicProgramGroupByYear(int academicProgramId);
    public Task<object> GetEvaluationByAcademicProgramId(int academicProgramId);
}
