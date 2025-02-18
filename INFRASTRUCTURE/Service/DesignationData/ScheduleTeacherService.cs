using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.ScheduleTeacher;
using APPLICATION.IService.DesignationData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.DesignationData;

public class ScheduleTeacherService:GenericService<ScheduleTeacher, GetScheduleTeacherDto>, IScheduleTeacherService
{
    public ScheduleTeacherService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<bool> IsTeacher(string userId)
    {
        return await _dbModel.AnyAsync(st => st.TeacherUserId == userId);
    }

    public async new Task<ScheduleTeacher?> GetAsync(int id)
    {
        var scheduleTeacher = await _dbModel
            .Include(st => st.TeacherUser)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
            .Include(st => st.Schedule)
                    .ThenInclude(cd => cd.Cycle)
            .Where(st => st.Id == id)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        return scheduleTeacher;
    }

    public async Task<object> GetScheduleTeacherByUserId(string userId)
    {
        return await _dbModel
            .Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                            .ThenInclude(ap => ap.College)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.Cycle)
            .Include(st => st.EnrollmentRole)
            .Where(st => st.TeacherUserId == userId)
            .Select(st => new
            {
                Id = st.Schedule.Id,
                GeneratedReference = st.Schedule.GeneratedReference,
                GeneratedSection = st.Schedule.GeneratedSection,
                AcademicProgramId = st.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
                AcademicProgram = new
                {
                    Id = st.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
                    ProgramName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                    ShortName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
                    CollegeId = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId,
                    College = (College) null,
                },
                CycleId = st.Schedule.CycleId,
                Cycle = st.Schedule.Cycle,
                CourseId = st.Schedule.CurriculumDetail.CourseId,
                Course = st.Schedule.CurriculumDetail.Course,
                MinStudent = st.Schedule.MinStudent,
                MaxStudent = st.Schedule.MaxStudent,
                IsPetitionSchedule = st.Schedule.IsPetitionSchedule,
                IsExclusive = st.Schedule.IsExclusive,
                CreatedByUser = st.Schedule.CreatedByUser,
                CollegeId = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId,
                College = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College,
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
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Curriculum)
                            .ThenInclude(c => c.AcademicProgram)
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
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                            .ThenInclude(ap => ap.College)
                                .ThenInclude(c => c.Campus)
            .Where(st => st.TeacherUserId == userId)
            .ToListAsync();

        return items.Select(st => _mapper.Map<GetCampusDto>(st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus)).Distinct().ToList();
    }

    public async Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByUserAndCampusId(string userId, int campusId)
    {
        var items = await _dbModel.
            Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                            .ThenInclude(ap => ap.College)
                                .ThenInclude(c => c.Campus)
            .Where(st => st.TeacherUserId == userId)
            .ToListAsync();
        return items.Select(st => new GetAcademicProgramDto
        {
            Id = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.Id,
            ProgramName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
            ShortName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
            YearFirstImplemented = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.YearFirstImplemented,
        }).Distinct().ToList();
    }
}
