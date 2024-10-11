using APPLICATION.Dto.GradeBookScore;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IGradeBookScoreService:IGenericService<GradeBookScore, GetGradeBookScoreDto>
{
    public Task<object?> GetEnrolledStudentWithOrWithoutScoreByGradeBookItemDetailsId(int gradeBookItemDetailsId);
    public Task<object?> GiveScoreMultiple(GiveGradeBookScoreGroupDto item);
    public Task<object> GetStudentGradeBookInformationByScheduleAndStudentId(int scheduleId, int studentId);
}
