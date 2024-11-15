using APPLICATION.Dto.EnrollmentGrade;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentGradeService:IGenericService<EnrollmentGrade, GetEnrollmentGradeDto>
{
    public Task<object> GetPostedGradesByStudentUserId(string userId);
    public Task<object> GetAssessmentsByStudentUserId(string userId);
    public Task<object?> PostOrUnPostGrade(int enrollmentId, int gradingPeriodId, string userId, bool post);
    public Task<object?> PostOrUnPostGradeByScheduleId(int scheduleId, int gradingPeriodId, string userId, bool post);
}
