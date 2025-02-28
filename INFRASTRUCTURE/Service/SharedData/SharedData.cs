
using APPLICATION.Dto.User;
using AutoMapper;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using APPLICATION.IService.SharedData;

namespace INFRASTRUCTURE.Service.SharedData;

public class SharedData: ISharedData
{
    protected readonly AppDbContext _dbContext;
    protected readonly IMapper _mapper;

    public SharedData(AppDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<object> GetStudentsByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    )
    {
        var students = _dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                            .ThenInclude(c => c.College)
                                .ThenInclude(c => c.Campus)
            .AsQueryable();

        // Apply filtering based on ContextType
        switch (type)
        {
            case ContextType.ProgramChair:
                students = students.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgramId == referenceId);
                break;
            case ContextType.CollegeDean:
                students = students.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId == referenceId);
                break;
            case ContextType.Registrar:
                students = students.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == referenceId);
                break;
        }

        var studentData = (await students.ToListAsync())
            .GroupBy(e => e.StudentUserId)
            .Select(g => g.OrderByDescending(e => e.YearLevel).First())
            .Select(e => new
            {
                Student = _mapper.Map<GetUserOnlyDto>(e.StudentUser),
                Section = e.Schedule.GeneratedSection,
                Curriculum = new
                {
                    Id = e.Schedule.CurriculumDetail.Curriculum.Id,
                    CurriculumName = e.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                    CurriculumCode = e.Schedule.CurriculumDetail.Curriculum.CurriculumCode
                },
                Campus = e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.CampusName,
                College = e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CollegeName,
                CurrentYearLevel = e.YearLevel,
                CurrentProgram = $"{e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName} ({e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName})"
            })
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToList();

        return new
        {
            Data = studentData,
            PaginationMeta = new
            {
                Page = page,
                Rows = rows,
                TotalItems = studentData.Select(s => s.Student.Id).Distinct().Count()
            }
        };
    }

    public async Task<object> GetTeachersByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    )
    {
        var teachers = _dbContext.ScheduleTeachers
            .OrderByDescending(e => e.Schedule.CurriculumDetail.Curriculum.CreatedDate)
            .Include(st => st.TeacherUser)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Curriculum)
            .Include(st => st.TeacherUser)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Course)
            .AsQueryable();

        switch (type)
        {
            case ContextType.ProgramChair:
                teachers = teachers.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgramId == referenceId);
                break;
            case ContextType.CollegeDean:
                teachers = teachers.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId == referenceId);
                break;
            case ContextType.Registrar:
                teachers = teachers.Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == referenceId);
                break;
        }

        var teacherData = (await teachers.ToListAsync())
            .GroupBy(t => t.TeacherUserId)
            .Select(t => t.First())
            .Select(st => new
            {
                Teacher = _mapper.Map<GetUserOnlyDto>(st.TeacherUser),
                Curriculum = new
                {
                    Id = st.Schedule.CurriculumDetail.Curriculum.Id,
                    CurriculumName = st.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                    CurriculumCode = st.Schedule.CurriculumDetail.Curriculum.CurriculumCode
                },
                Courses = teachers
                    .Where(t => t.TeacherUserId == st.TeacherUserId)
                    .OrderByDescending(t => t.Schedule.CurriculumDetail.Curriculum.CreatedDate)
                    .Select(t => new
                    {
                        Id = t.Schedule.CurriculumDetail.CourseId,
                        CourseTitle = t.Schedule.CurriculumDetail.Course.CourseTitle,
                        CourseCode = t.Schedule.CurriculumDetail.Course.CourseCode,
                        CourseDesscription = t.Schedule.CurriculumDetail.Course.CourseDescription,
                    }).Distinct()
            })
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToList();

        return new
        {
            Data = teacherData,
            PaginationMeta = new
            {
                Page = page,
                Rows = rows,
                TotalItems = teacherData.Select(t => t.Teacher.Id).Distinct().Count(),
            }
        };
    }

    public async Task<object> GetCurriculumByContext(
        int referenceId,
        int page,
        int rows,
        ContextType type
    )
    {
        var curriculaList = _dbContext.Curricula
            .Include(c => c.AcademicProgram)
                .ThenInclude(ap => ap.College)
                    .ThenInclude(col => col.Campus)
            .AsNoTracking();

        switch (type)
        {
            case ContextType.ProgramChair:
                curriculaList = curriculaList.Where(c => c.AcademicProgram.Id == referenceId);
                break;
            case ContextType.CollegeDean:
                curriculaList = curriculaList.Where(c => c.AcademicProgram.CollegeId == referenceId);
                break;
            case ContextType.Registrar:
                curriculaList = curriculaList.Where(c => c.AcademicProgram.College.CampusId == referenceId);
                break;
        }

        // Sorting before grouping
        var sortedCurricula = curriculaList
            .OrderByDescending(c => c.CreatedDate)
            .ThenBy(c => c.AcademicProgram.College.Campus.CampusName)
            .ThenBy(c => c.AcademicProgram.College.CollegeName)
            .ThenBy(c => c.AcademicProgram.ProgramName);

        // Group by Campus → College → Academic Programs → Curricula
        var groupedData = sortedCurricula
            .GroupBy(c => new
            {
                CampusId = c.AcademicProgram.College.Campus.Id,
                CampusName = c.AcademicProgram.College.Campus.CampusName
            })
            .Select(campusGroup => new
            {
                Campus = campusGroup.Key.CampusName,
                Colleges = campusGroup
                    .GroupBy(c => new { CollegeId = c.AcademicProgram.College.Id, CollegeName = c.AcademicProgram.College.CollegeName })
                    .Select(collegeGroup => new
                    {
                        Id = collegeGroup.Key.CollegeId,
                        Name = collegeGroup.Key.CollegeName,
                        Programs = collegeGroup
                            .GroupBy(c => new { ProgramId = c.AcademicProgram.Id, ProgramName = c.AcademicProgram.ProgramName })
                            .Select(programGroup => new
                            {
                                Id = programGroup.Key.ProgramId,
                                Name = programGroup.Key.ProgramName,
                                ShortName = programGroup.First().AcademicProgram.ShortName,
                                Curricula = programGroup
                                    .OrderByDescending(c => c.CreatedDate)
                                    .Select(c => new
                                    {
                                        Id = c.Id,
                                        c.CurriculumName,
                                        c.CurriculumCode,
                                        c.Major,
                                        c.Minor,
                                        c.AuthorityLegal,
                                        c.StartDate,
                                        c.StudentMaxUnits,
                                        c.MinUnitsToBeHonored,
                                        c.MinGradeToBeCulledId,
                                        c.MinGradeToBeCulled,
                                        c.AcademicTermId,
                                        c.AcademicTerm,
                                        c.TotalAcademicTerm,
                                        c.IsActive,
                                        c.IsDefault,
                                        c.CreatedDate,
                                    })
                                    .ToList()
                            })
                            .ToList()
                    })
                    .ToList()
            })
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToList();

        return new
        {
            Data = groupedData,
            PaginationMeta = new
            {
                Page = page,
                Rows = rows,
                TotalCount = sortedCurricula.Select(c => c.AcademicProgram.College.Campus.Id).Distinct().Count()
            }
        };
    }

}
