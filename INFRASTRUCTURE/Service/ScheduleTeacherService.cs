using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Campus;
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

    public async Task<object> GetScheduleTeacherByUserId(string userId)
    {
        return await _dbModel
            .Include(st => st.Schedule)
                .ThenInclude(s => s.Course)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.Cycle)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.AcademicProgram)
                    .ThenInclude(ap => ap.College)
            .Include(st => st.EnrollmentRole)
            .Where(st => st.TeacherUserId == userId)
            .Select(st => new
            {
                Id = st.Schedule.Id,
                GeneratedReference = st.Schedule.GeneratedReference,
                GeneratedSection = st.Schedule.GeneratedSection,
                AcademicProgramId = st.Schedule.AcademicProgramId,
                AcademicProgram = st.Schedule.AcademicProgram,
                CycleId = st.Schedule.CycleId,
                Cycle = st.Schedule.Cycle,
                CourseId = st.Schedule.CourseId,
                Course = st.Schedule.Course,
                DaySchedule = st.Schedule.DaySchedule,
                TimeScheduleIn = st.Schedule.TimeScheduleIn,
                TimeScheduleOut = st.Schedule.TimeScheduleOut,
                RoomId = st.Schedule.RoomId,
                Room = st.Schedule.Room,
                MinStudent = st.Schedule.MinStudent,
                MaxStudent = st.Schedule.MaxStudent,
                IsPetitionSchedule = st.Schedule.IsPetitionSchedule,
                IsExclusive = st.Schedule.IsExclusive,
                CreatedByUser = st.Schedule.CreatedByUser,
                CollegeId = st.Schedule.AcademicProgram.CollegeId,
                College = st.Schedule.AcademicProgram.College,
            })
            .ToListAsync();
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

    public async Task<ICollection<GetCampusDto>> GetTeacherScheduleWhereHeOrSheTeach(string userId)
    {
        var items = await _dbModel.
            Include(st => st.Schedule)
                .ThenInclude(s => s.Room)
                    .ThenInclude(r => r.Building)
                        .ThenInclude(b => b.Campus)
            .Where(st => st.TeacherUserId == userId)
            .ToListAsync();

        return items.Select(st => _mapper.Map<GetCampusDto>(st.Schedule.Room.Building.Campus)).Distinct().ToList();
    }

    public async Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByUserAndCampusId(string userId, int campusId)
    {
        var items = await _dbModel.
            Include(st => st.Schedule)
                .ThenInclude(s => s.AcademicProgram)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.Room)
                        .ThenInclude(r => r.Building)
                            .ThenInclude(b => b.Campus)
            .Where(st => st.TeacherUserId == userId)
            .Where(st => st.Schedule.Room.Building.CampusId == campusId)
            .ToListAsync();
        return items.Select(st => _mapper.Map<GetAcademicProgramDto>(st.Schedule.AcademicProgram)).Distinct().ToList();
    }
}
