
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EnrollmentService:GenericService<Enrollment>, IEnrollmentService
{
    public EnrollmentService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Enrollment>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId)
    {
        return await _dbModel
            .Include(e => e.EnrollmentRole)
            .Where(e => e.EnrollmentRoleId == enrollmentRoleId)
            .ToListAsync();
    }

    public async Task<ICollection<Enrollment>> GetEnrollmentsByScheduleId(int scheduleId)
    {
        return await _dbModel
            .Include(e => e.EnrollmentRole)
            .Include(e => e.Schedule)
            .Where(e => e.ScheduleId == scheduleId)
            .ToListAsync();
    }
}
