
using APPLICATION.Dto.Enrollment;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EnrollmentService:GenericService<Enrollment, GetEnrollmentDto>, IEnrollmentService
{
    public EnrollmentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId)
    {
        return _mapper.Map<ICollection<GetEnrollmentDto>>(await _dbModel
            .Include(e => e.EnrollmentRole)
            .Where(e => e.EnrollmentRoleId == enrollmentRoleId)
            .ToListAsync());
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByScheduleId(int scheduleId)
    {
        return _mapper.Map<ICollection<GetEnrollmentDto>>(await _dbModel
            .Include(e => e.EnrollmentRole)
            .Include(e => e.Schedule)
            .Include(e => e.StudentUser)
            .Where(e => e.ScheduleId == scheduleId)
            .ToListAsync());
    }
}
