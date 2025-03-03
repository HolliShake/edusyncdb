
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
        var query = _dbContext.Enrollments
        .AsNoTracking()
        .Where(e => e.StudentUser != null)
        .Select(e => new
        {
            StudentUser = e.StudentUser,
            Curriculum = new
            {
                e.Schedule.CurriculumDetail.Curriculum.Id,
                e.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                e.Schedule.CurriculumDetail.Curriculum.CurriculumCode,
                AcademicProgram = new
                {
                    e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.Id,
                    e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                    e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
                    College = new
                    {
                        e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Id,
                        e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CollegeName,
                        Campus = new
                        {
                            e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.Id,
                            e.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.CampusName
                        }
                    }
                }
            }
        });

        // Apply optimized filtering
        query = type switch
        {
            ContextType.ProgramChair => query.Where(e => e.Curriculum.AcademicProgram.Id == referenceId),
            ContextType.CollegeDean => query.Where(e => e.Curriculum.AcademicProgram.College.Id == referenceId),
            ContextType.Registrar => query.Where(e => e.Curriculum.AcademicProgram.College.Campus.Id == referenceId),
            _ => query
        };

        // Optimized count query
        var totalCount = await query.Select(e => e.StudentUser.Id).Distinct().CountAsync();

        var dbResult = await query
            .GroupBy(e => e.StudentUser)
            .Select(g => new
            {
                StudentUser = g.Key,
                Curriculum = g.Select(x => x.Curriculum).Distinct(),
                Campus = g.Select(x => x.Curriculum.AcademicProgram.College.Campus).Distinct(),
                College = g.Select(x => x.Curriculum.AcademicProgram.College).Distinct(),
                AcademicProgram = g.Select(x => x.Curriculum.AcademicProgram).Distinct()
            })
            .OrderBy(x => x.StudentUser.LastName)
            .ThenBy(x => x.StudentUser.FirstName)
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();

        // Client-side transformations
        var studentData = dbResult.Select(g => new
        {
            Student = _mapper.Map<GetUserOnlyDto>(g.StudentUser),
            Curriculum = g.Curriculum.Select(c => new { c.Id, c.CurriculumName, c.CurriculumCode }),
            Campus = g.Campus.Select(c => new { c.Id, c.CampusName }),
            College = g.College.Select(c => new { c.Id, c.CollegeName }),
            CurrentProgram = g.AcademicProgram.Select(p => new {
                p.Id,
                ProgramName = $"{p.ProgramName} ({p.ShortName})"
            })
        }).ToList();

        // Pre-materialize filters
        var campusFilter = studentData.SelectMany(s => s.Campus).Distinct().ToList();
        var collegeFilter = studentData.SelectMany(s => s.College).Distinct().ToList();
        var curriculumFilter = studentData.SelectMany(s => s.Curriculum).Distinct().ToList();
        var programFilter = studentData.SelectMany(s => s.CurrentProgram).Distinct().ToList();

        return new
        {
            Data = studentData,
            PaginationMeta = new
            {
                CampusFilter = campusFilter.Select(c => new { Label = c.CampusName, Value = c.Id }),
                CollegeFilter = collegeFilter.Select(c => new { Label = c.CollegeName, Value = c.Id }),
                CurriculumFilter = curriculumFilter.Select(c => new {
                    Label = c.CurriculumName,
                    Subtitle = c.CurriculumCode,
                    Value = c.Id
                }),
                ProgramFilter = programFilter.Select(p => new { Label = p.ProgramName, Value = p.Id }),
                Page = page,
                Rows = rows,
                TotalItems = totalCount
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
        var query = _dbContext.ScheduleTeachers
        .AsNoTracking()
        .Select(st => new
        {
            TeacherUser = st.TeacherUser,
            Curriculum = new
            {
                st.Schedule.CurriculumDetail.Curriculum.Id,
                st.Schedule.CurriculumDetail.Curriculum.CurriculumName,
                st.Schedule.CurriculumDetail.Curriculum.CurriculumCode
            },
            AcademicProgram = new
            {
                st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.Id,
                st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
                CollegeId = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Id,
                CollegeName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CollegeName,
                CampusId = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.Id,
                CampusName = st.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.CampusName
            },
            Course = new
            {
                st.Schedule.CurriculumDetail.Course.Id,
                st.Schedule.CurriculumDetail.Course.CourseTitle,
                st.Schedule.CurriculumDetail.Course.CourseCode,
                st.Schedule.CurriculumDetail.Course.CourseDescription
            }
        });

        // Apply filtering
        query = type switch
        {
            ContextType.ProgramChair => query.Where(e => e.AcademicProgram.Id == referenceId),
            ContextType.CollegeDean => query.Where(e => e.AcademicProgram.CollegeId == referenceId),
            ContextType.Registrar => query.Where(e => e.AcademicProgram.CampusId == referenceId),
            _ => query
        };

        // Get teacher IDs for count
        var totalCount = await query.Select(x => x.TeacherUser.Id).Distinct().CountAsync();

        var teacherData = await query
            .GroupBy(x => x.TeacherUser)
            .Select(g => new
            {
                TeacherUser = g.Key,
                Curriculum = g.Select(x => x.Curriculum).Distinct(),
                Campus = g.Select(x => new { Id = x.AcademicProgram.CampusId, x.AcademicProgram.CampusName }).Distinct(),
                College = g.Select(x => new { Id = x.AcademicProgram.CollegeId, x.AcademicProgram.CollegeName }).Distinct(),
                Courses = g.Select(x => x.Course).Distinct(),
                AcademicPrograms = g.Select(x => new { x.AcademicProgram.Id, x.AcademicProgram.ProgramName, x.AcademicProgram.ShortName }).Distinct()
            })
            .OrderBy(x => x.TeacherUser.LastName)
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();

        // Client-side mapping
        var resultData = teacherData.Select(t => new
        {
            Teacher = _mapper.Map<GetUserOnlyDto>(t.TeacherUser),
            Curriculum = t.Curriculum,
            Campus = t.Campus,
            College = t.College,
            Courses = t.Courses,
            CurrentProgram = t.AcademicPrograms.Select(p => new {
                p.Id,
                ProgramName = $"{p.ProgramName} ({p.ShortName})"
            })
        }).ToList();

        return new
        {
            Data = resultData,
            PaginationMeta = new
            {
                CampusFilter = resultData.SelectMany(sd => sd.Campus)
                    .Distinct()
                    .Select(c => new { Label = c.CampusName, Value = c.Id }),
                CollegeFilter = resultData.SelectMany(sd => sd.College)
                    .Distinct()
                    .Select(c => new { Label = c.CollegeName, Value = c.Id }),
                CurriculumFilter = resultData.SelectMany(sd => sd.Curriculum)
                    .Distinct()
                    .Select(c => new { Label = c.CurriculumName, Subtitle = c.CurriculumCode, Value = c.Id }),
                ProgramFilter = resultData.SelectMany(sd => sd.CurrentProgram)
                    .Distinct()
                    .Select(p => new { Label = p.ProgramName, Value = p.Id }),
                Page = page,
                Rows = rows,
                TotalItems = totalCount
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
        var groupedData = await sortedCurricula
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
            .ToListAsync();

        return new
        {
            Data = groupedData,
            PaginationMeta = new
            {
                Page = page,
                Rows = rows,
                TotalItems = sortedCurricula.Select(c => c.AcademicProgram.College.Campus.Id).Distinct().Count()
            }
        };
    }

}
