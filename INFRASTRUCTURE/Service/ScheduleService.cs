using APPLICATION.Dto.Schedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleService:GenericService<Schedule, GetScheduleDto>, IScheduleService
{
    public ScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.AcademicProgramId == academicProgramId)
            .ToListAsync());
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByRoomId(int roomId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.RoomId == roomId)
            .ToListAsync());
    }
    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.CycleId == cycleId)
            .ToListAsync());
    }
    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.CourseId == courseId)
            .ToListAsync());
    }
}
