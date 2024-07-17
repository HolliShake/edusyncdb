
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleService:GenericService<Schedule>, IScheduleService
{
    public ScheduleService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Schedule>> GetSchedulesByAcademicProgramId(int academicProgramId)
    {
        return await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.AcademicProgramId == academicProgramId)
            .ToListAsync();
    }

    public async Task<ICollection<Schedule>> GetSchedulesByRoomId(int roomId)
    {
        return await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.RoomId == roomId)
            .ToListAsync();
    }
    public async Task<ICollection<Schedule>> GetSchedulesByCycleId(int cycleId)
    {
        return await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.CycleId == cycleId)
            .ToListAsync();
    }
    public async Task<ICollection<Schedule>> GetSchedulesByCourseId(int courseId)
    {
        return await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
            .Include(s => s.Cycle)
            .Where(s => s.CourseId == courseId)
            .ToListAsync();
    }
}
