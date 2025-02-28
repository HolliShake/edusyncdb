
using APPLICATION.Dto.Enrollment;
using DOMAIN.Model;

namespace APPLICATION.IService.EnrollmentData;

public interface IEnrollmentService:IGenericService<Enrollment, GetEnrollmentDto>
{
    public Task<bool> IsStudent(string userId);
    public Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId);
    public Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByScheduleId(int scheduleId);
    public Task<object> GetEnrolledUserWithEClearanceTagByCampusIdPaginated(int campusId, string? student, int page, int rows);
    public Task<object> GetEnrollmentsWithScoreByScheduleId(int scheduleId);
    public Task<object> GetEnrollmentsByStudentUserId(string userId);
    public Task<object> GetUserTodaysScheduleIfEnrolled(string userId);
}
