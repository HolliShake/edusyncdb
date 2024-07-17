
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentService:IGenericService<Enrollment>
{
    public Task<ICollection<Enrollment>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId);
    public Task<ICollection<Enrollment>> GetEnrollmentsByScheduleId(int scheduleId);
}
