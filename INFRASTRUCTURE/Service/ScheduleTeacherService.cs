using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.ScheduleTeacher;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
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

    public async Task<object> GetTeacherScheduleGradeBookByUserIdAndAcademicProgramId(string userId, int academicProgramId)
    {
        var items = _dbModel
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.Cycle)
                .Include(st => st.Schedule)
                   .ThenInclude(s => s.GradeBooks)
                //.ThenInclude(gb => gb.Schedule)
                //.ThenInclude(s => s.GradeBooks)
                //.Include(st => st.EnrollmentRole)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.AcademicProgram)
                .Where(st => st.TeacherUserId == userId)
                .ToList();

        List<object> datas = [];

        foreach (var item in items)
        {
            datas.AddRange(item.Schedule.GradeBooks.Select(gb => new
            {
                GradeBookId = gb.Id,
                GradeBookName = gb.GradeBookDescription,
                ScheduleId = gb.ScheduleId,
                Schedule = gb.Schedule,
            }));
        }

        return datas;
    }

    public async Task<object> GetTeacherScheduleGradeBookByUserId(string userId)
    {
        var items = _dbModel
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.Cycle)
                .Include(st => st.Schedule)
                   .ThenInclude(s => s.GradeBooks)
                        //.ThenInclude(gb => gb.Schedule)
                    //.ThenInclude(s => s.GradeBooks)
                        //.Include(st => st.EnrollmentRole)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.AcademicProgram)
                .Where(st => st.TeacherUserId == userId)
                .ToList();

        List<object> datas = [];

        /*
        foreach (var item in items)
        {
            datas.AddRange(item.Schedule.GradeBooks.Select(gb => new
            {
                GradeBookId = gb.Id,
                GradeBookName = gb.GradeBookDescription,
                ScheduleId = gb.ScheduleId,
                //Schedule = gb.Schedule,
            }));
        }
        */

        return datas;
    }
}
