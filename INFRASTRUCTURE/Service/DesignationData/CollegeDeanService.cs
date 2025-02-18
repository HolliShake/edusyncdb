using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using APPLICATION.Dto.CollegeDean;
using APPLICATION.Dto.User;
using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.College;
using APPLICATION.Dto.Curriculum;
using APPLICATION.Dto.FileManager;
using APPLICATION.IService.DesignationData;

namespace INFRASTRUCTURE.Service.DesignationData;

public class CollegeDeanService:GenericService<CollegeDean, GetCollegeDeanDto>, ICollegeDeanService
{
    public CollegeDeanService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> DashboardData(string userId)
    {
        return 1;
    }

    public async Task<bool> IsCollegeDean(string userId)
    {
        return await _dbModel.AnyAsync(cd => cd.UserId == userId);
    }

    public async Task<GetCollegeDto> GetCollegeByUserId(string userId)
    {
        return _mapper.Map<GetCollegeDto>(await _dbModel
            .Include(apc => apc.College)
            .Where(apc => apc.UserId == userId)
            .Select(apc => _mapper.Map<GetCollegeDto>(apc.College))
            .SingleOrDefaultAsync());
    }

    public async new Task<ICollection<GetCollegeDeanDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetCollegeDeanDto>>(await _dbModel.Include(cd => cd.College).ThenInclude(c => c.Campus).Include(cd => cd.User).ToListAsync())
            .Select(cd =>
            {
                var data = _dbContext.FileTables.Where(ft => ft.ReferenceId == cd.UserId).Where(ft => ft.Scope == "User:Profile").FirstOrDefault();
                cd.User.ProfileImage = _mapper.Map<GetFileManagerTableDto>(data)?.ScopePath ?? string.Empty;
                return cd;
            }).ToList();
    }

    public async Task<object> GetAllProgramChairByCollegeId(int collegeId)
    {
        var programChairs = await _dbContext.AcademicProgramChairs
            .Include(apc => apc.AcademicProgram)
            .Include(apc => apc.User)
            .Where(ap => ap.AcademicProgram.CollegeId == collegeId)
            .ToListAsync();
        return programChairs.Select(pc => new
        {
            Id = pc.Id,
            UserId = pc.User.Id,
            User = _mapper.Map<GetUserOnlyDto>(pc.User),
            AcademicProgramId = pc.AcademicProgramId,
            AcademicProgram = _mapper.Map<GetAcademicProgramDto>(pc.AcademicProgram),
        });
    }

    public async Task<object> GetStudentByCollegeId(int collegeId)
    {
        var students = await _dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
            .Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId == collegeId)
            .GroupBy(e => e.StudentUserId)
            .OrderByDescending(e => e.Select(e => e.YearLevel).First())
            .Select(e => e.First())
            .Distinct()
            .ToListAsync();
        return students.Select(e => new
        {
            Id = e.Id,
            Student = _mapper.Map<GetUserOnlyDto>(e.StudentUser),
            Section = e.Schedule.GeneratedSection,
            Curriculum = new
            {
                Id = e.Schedule.CurriculumDetail.Curriculum.Id,
                CurriculumName = e.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                CurriculumCode = e.Schedule.CurriculumDetail.Curriculum.CurriculumCode,
            },
            YearLevel = $"{Utility.AddSuffix(e.YearLevel)} Year",
            AcademicProgram = _mapper.Map<GetAcademicProgramDto>(e.Schedule.CurriculumDetail.Curriculum.AcademicProgram),
        });
    }

    public async Task<object> GetTeacherByCollegeId(int collegeId)
    {
        var teachers = await _dbContext.ScheduleTeachers
            .Include(st => st.TeacherUser)
            .Include(st => st.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
            .Where(st => st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId == collegeId)
            .GroupBy(st => st.TeacherUserId)
            .Select(st => st.First())
            .ToListAsync();

        return teachers.Select(t => t.TeacherUser).Distinct().Select(t => new
        {
            Teacher = _mapper.Map<GetUserOnlyDto>(t),
            AcademicPrograms = _mapper.Map<ICollection<GetAcademicProgramDto>>(teachers.Where(st => st.TeacherUserId == t.Id).Select(st => st.Schedule.CurriculumDetail.Curriculum.AcademicProgram)),
            Curriculums = _mapper.Map<ICollection<GetCurriculumDto>>(teachers.Where(st => st.TeacherUserId == t.Id).Select(st => st.Schedule.CurriculumDetail.Curriculum).ToList()),
            Sections = teachers.Where(st => st.TeacherUserId == t.Id).Select(st => new
            {
                ScheduleId = st.ScheduleId,
                GeneratedSection = st.Schedule.GeneratedSection,
                GeneratedReference = st.Schedule.GeneratedReference
            })
        });
    }

    public async Task<object> GetStudentsWithUnClearedStatus(int collegeId)
    {
        var students = await _dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
            .Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId == collegeId)
            .GroupBy(e => e.StudentUserId)
            .OrderByDescending(e => e.Select(e => e.YearLevel).First())
            .Select(e => e.First())
            .Distinct()
            .ToListAsync();
        return students.Select(e =>
        {
            var tags = _dbContext.ClearanceTags
                .Include(ct => ct.ClearanceType)
                .Include(ct => ct.DuWhoTag)
                .Where(ct => ct.UnclearedUserId == e.StudentUserId)
                .ToList()
                .Select(ct => new
                {
                    Id = ct.Id,
                    ClearanceTypeId = ct.ClearanceTypeId,
                    ClearanceType = ct.ClearanceType,
                    isSettled = ct.IsSettled,
                    DateCreated = ct.DateCreated,
                    SettledDate = ct.SettledDate,
                    DuWhoTag = _mapper.Map<GetUserOnlyDto>(ct.DuWhoTag),
                    UserWhoCleared = _mapper.Map<GetUserOnlyDto>(ct.UserWhoCleared)
                });

            var isCleared = !tags.Where(t => !t.isSettled).Any() || !tags.Any();

            return (new
            {
                Id = e.Id,
                Student = _mapper.Map<GetUserOnlyDto>(e.StudentUser),
                Section = e.Schedule.GeneratedSection,
                Curriculum = new
                {
                    Id = e.Schedule.CurriculumDetail.Curriculum.Id,
                    CurriculumName = e.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                    CurriculumCode = e.Schedule.CurriculumDetail.Curriculum.CurriculumCode,
                },
                YearLevel = $"{Utility.AddSuffix(e.YearLevel)} Year",
                AcademicProgram = _mapper.Map<GetAcademicProgramDto>(e.Schedule.CurriculumDetail.Curriculum.AcademicProgram),
                IsCleared = isCleared,
                Tags = tags,
            });
        });
    }

    public async Task<object> GetCurriculumPerAcademicProgramByCollegeId(int collegeId)
    {
        var curriculum = await _dbContext.Curricula
            .Include(c => c.AcademicProgram)
                .ThenInclude(ap => ap.College)
            .Where(c => c.AcademicProgram.CollegeId == collegeId)
            .ToListAsync();
        return curriculum.Select(c => c.AcademicProgram).Distinct().Select(ap => new
        {
            AcademicProgram = new
            {
                Id = ap.Id,
                ProgramName = ap.ProgramName,
                ShortName = ap.ShortName,
                YearFirstImplemented = ap.YearFirstImplemented,
                CollegeId = ap.CollegeId,
                College = (College) null
            },
            Curriculums = _mapper.Map<ICollection<GetCurriculumDto>>(curriculum.Where(c => c.AcademicProgramId == ap.Id).ToList())
                .Select(c =>
                {
                    c.AcademicProgram = null;
                    return c;
                })
        });
    }
}
