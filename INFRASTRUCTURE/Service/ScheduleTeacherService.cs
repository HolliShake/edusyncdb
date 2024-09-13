using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.ScheduleTeacher;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleTeacherService:GenericService<ScheduleTeacher, GetScheduleTeacherDto>, IScheduleTeacherService
{
    public ScheduleTeacherService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetScheduleDto>> GetScheduleTeacherByUserId(string userId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(st => st.Schedule)
            .Include(st => st.EnrollmentRole)
            .Where(st => st.TeacherUserId == userId)
            .Select(st => st.Schedule)
            .ToListAsync());
    }

    public async Task<bool> HasShedule(string userId, int scheduleId)
    {
        return await _dbModel
            .AnyAsync(st => st.TeacherUserId == userId && st.ScheduleId == scheduleId);
    }
}
