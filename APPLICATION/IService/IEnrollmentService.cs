
using APPLICATION.Dto.Enrollment;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentService:IGenericService<Enrollment, GetEnrollmentDto>
{
    public Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId);
    public Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByScheduleId(int scheduleId);
}