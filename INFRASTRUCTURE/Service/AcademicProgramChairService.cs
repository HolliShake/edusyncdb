
using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.AcademicProgramChair;
using APPLICATION.Dto.Course;
using APPLICATION.Dto.Curriculum;
using APPLICATION.Dto.Cycle;
using APPLICATION.Dto.Instrument;
using APPLICATION.Dto.User;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AcademicProgramChairService:GenericService<AcademicProgramChair, GetAcademicProgramChairDto>, IAcademicProgramChairService
{
    public AcademicProgramChairService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<GetAcademicProgramDto?> GetAcademicProgramByUserId(string userId)
    {
        return _mapper.Map<GetAcademicProgramDto>(await _dbModel
            .Include(apc => apc.AcademicProgram)
            .Where(apc => apc.UserId == userId)
            .Select(apc => _mapper.Map<GetAcademicProgramDto>(apc.AcademicProgram))
            .SingleOrDefaultAsync());
    }

    public async Task<object> GetStudentsByAcademicProgram(int academicProgramId, int limit)
    {
        var students = await _dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
            .Take(limit > 0 ? limit : int.MaxValue)
            .Where(e => e.Schedule.CurriculumDetail.Curriculum.AcademicProgramId == academicProgramId)
            .OrderByDescending(e => e.Schedule.CurriculumDetail.Curriculum.CreatedDate)
            .ToListAsync();
        return students
            .GroupBy(e => e.StudentUserId)
            .Select(g => g.OrderByDescending(g => g.YearLevel).First())
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
                YearLevel = e.YearLevel
            });
    }

    public async Task<object> GetTeachersByAcademicProgram(int academicProgramId, int limit)
    {
        var teachers = await _dbContext.ScheduleTeachers
            .Where(st => st.Schedule.CurriculumDetail.Curriculum.AcademicProgramId == academicProgramId)
            .OrderByDescending(e => e.Schedule.CurriculumDetail.Curriculum.CreatedDate)
            .Include(st => st.TeacherUser)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Curriculum)
            .Include(st => st.TeacherUser)
                .Include(st => st.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Course)
            .Take(limit > 0 ? limit : int.MaxValue)
            .ToListAsync();

        return teachers.GroupBy(t => t.TeacherUserId).Select(t => t.First()).Select(st => new
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
        });
    }

    public async Task<object> GetActiveCurriculumCoursesByAcademicProgram(int academicProgramId)
    {
        var courses = await _dbContext.CurriculumDetails
            .Include(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
            .Include(cd => cd.Course)
                .ThenInclude(c => c.CourseRequisites)
            .Where(cd => cd.Curriculum.AcademicProgramId == academicProgramId)
            .Where(cd => cd.Curriculum.IsActive || cd.Curriculum.IsDefault)
            .OrderByDescending(cd => cd.Curriculum.CreatedDate)
            .Select(cd => cd.Course)
            .Distinct()
            .ToListAsync();
        return courses.Select(c => new
        {
            id = 7,
            courseTitle = c.CourseTitle,
            courseCode = c.CourseCode,
            courseDescription = c.CourseDescription,
            withLaboratory = c.WithLaboratory,
            isSpecialize = c.IsSpecialize,
            lectureUnits = c.LectureUnits,
            laboratoryUnits = c.LaboratoryUnits,
            creditUnits = c.CreditUnits,
            CourseRequisites = c.CourseRequisites.Select(cr => new
            {
                requisiteCourseId = cr.Id,
                type = cr.Type,
                typeName = cr.Type.ToString(),
                requisiteCourseTitle = cr.RequisiteCourse.CourseTitle,
                requisiteCourseCode = cr.RequisiteCourse.CourseCode,
                requisiteCourseDescription = cr.RequisiteCourse.CourseDescription,
            }),
        });
    }

    public async Task<object> GetCurriculumsByAcademicProgram(int academicProgramId)
    {
        var curricula = await _dbContext.Curricula
        .Include(c => c.AcademicTerm)
        .Include(c => c.AcademicProgram)
        .Include(c => c.ProgramType)
        .Include(c => c.MinGradeToBeCulled)
        .Where(c => c.AcademicProgramId == academicProgramId)
        .OrderByDescending(c => c.CreatedDate)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCurriculumDto>>(curricula);
    }

    public async Task<object> GetActiveCurriculumSectionsByAcademicProgram(int academicProgramId)
    {
        var schedules = await _dbContext.Schedules
            .Include(s => s.ScheduleAssignments)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgramId == academicProgramId)
            .Where(s => s.CurriculumDetail.Curriculum.IsActive || s.CurriculumDetail.Curriculum.IsDefault)
            .ToListAsync();
        return schedules
            .Select(s => s.GeneratedSection)
            .Distinct()
            .Select(s => new
            {
                GeneratedSection = s,
                Courses = schedules.Where(sec => sec.GeneratedSection == s)
                    .GroupBy(sec => sec.CurriculumDetail.CourseId)
                    .Select(sec => sec.First())
                    .Select(s => new
                    {
                        Id = s.Id,
                        Course = new
                        {
                            Id = s.CurriculumDetail.Course.Id,
                            CourdeTitle = s.CurriculumDetail.Course.CourseTitle,
                            CourseCode = s.CurriculumDetail.Course.CourseCode,
                            CourseDescription = s.CurriculumDetail.Course.CourseDescription
                        },
                        Schedules = s.ScheduleAssignments,
                    })
                    .ToList()
            });
    }

    public async Task<object> GetActiveCurriculumSectionsByAcademicProgramGroupByYear(int academicProgramId)
    {
        var schedules = await _dbContext.Schedules
            .Include(s => s.ScheduleAssignments)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgramId == academicProgramId)
            .ToListAsync();
        return schedules
            .Select(s => s.CurriculumDetail.YearLevel)
            .Distinct()
            .Select(year => new
            {
                YearLevel = year,
                YearLabel = $"{Utility.AddSuffix(year)} Year",
                Sections = schedules
                .Select(s => s.GeneratedSection)
                .Distinct()
                .Select(s => new
                {
                    GeneratedSection = s,
                    Courses = schedules.Where(sec => sec.GeneratedSection == s)
                        .GroupBy(sec => sec.CurriculumDetail.CourseId)
                        .Select(sec => sec.First())
                        .Select(s => new
                        {
                            Id = s.Id,
                            Course = new
                            {
                                Id = s.CurriculumDetail.Course.Id,
                                CourdeTitle = s.CurriculumDetail.Course.CourseTitle,
                                CourseCode = s.CurriculumDetail.Course.CourseCode,
                                CourseDescription = s.CurriculumDetail.Course.CourseDescription
                            },
                            Schedules = s.ScheduleAssignments,
                        })
                        .ToList()
                })
            });
    }

    public async Task<object> GetEvaluationByAcademicProgramId(int academicProgramId)
    {
        var evaluationPeriod = (await _dbContext.EvaluationPeriods
            .Include(ep => ep.Cycle)
            .Include(ep => ep.Instrument)
            .Where(ep => ep.AcademicProgramId == academicProgramId)
            .AsNoTracking()
            .ToListAsync())
            .Select(ep =>
            {
                var evalRating = _dbContext.EvaluationRatings
                    .Include(er => er.EvaluationRatingDetails)
                        .ThenInclude(erd => erd.LikertQuestion)
                    .Include(er => er.ScheduleTeacher)
                        .ThenInclude(st => st.TeacherUser)
                    .Include(er => er.ScheduleTeacher)
                        .ThenInclude(st => st.Schedule)
                            .ThenInclude(s => s.CurriculumDetail)
                                .ThenInclude(cd => cd.Course)
                    .Include(er => er.EvaluationRatingDetails)
                    .Where(er => er.EvaluationPeriodId == ep.Id)
                    .AsNoTracking()
                    .ToList();

                var totalNumber = evalRating.Count;
                var postedCount = evalRating.Count(er => er.IsPosted);
                var isPostedAll = totalNumber == postedCount;

                // List of teachers handling schedules within the current evaluation period
                var teachers = _dbContext.Schedules
                    .Include(s => s.Teachers)
                        .ThenInclude(st => st.Schedule)
                            .ThenInclude(sch => sch.CurriculumDetail)
                                .ThenInclude(cd => cd.Course)
                    .Include(s => s.Teachers)
                        .ThenInclude(st => st.TeacherUser)
                    .SelectMany(s => s.Teachers)
                    .Where(st => st.Schedule.CurriculumDetail.Curriculum.AcademicProgramId == ep.AcademicProgramId)
                    .Where(st => st.Schedule.CycleId == ep.CycleId)
                    .ToList()
                    .Select(st =>
                    {
                        // Find evaluations completed by this teacher's students
                        var evaluated = evalRating
                            .Where(er => er.ScheduleTeacherId == er.Id)
                            .ToList();

                        // Find students who haven't completed the evaluation
                        var notEvaluated = _dbContext.Enrollments
                            .Include(e => e.StudentUser)
                            .Where(e => st.ScheduleId == e.ScheduleId)
                            .AsNoTracking()
                            .ToList()
                            .Where(e => !evaluated.Any(alreadyEvaluated => alreadyEvaluated.EnrollmentId == e.Id))
                            .ToList();

                        var maxStudent = evaluated.Count + notEvaluated.Count;

                        return new
                        {
                            ScheduleTeacher = st,
                            EvaluatedCount = evaluated.Count,
                            NotEvaluatedCount = notEvaluated.Count,
                            MaximumStudent = maxStudent,
                            StudentsWhoDidNotEvaluate = notEvaluated.Select(e => new
                            {
                                ReferenceId = e.StudentUser.ReferenceId,
                                FullName = string.IsNullOrEmpty(e.StudentUser.LastName)
                                    ? e.StudentUser.Email
                                    : $"{e.StudentUser.LastName}, {e.StudentUser.FirstName}"
                            })
                        };
                    })
                    .ToList();

                var overAllStudentCount = teachers.Sum(t => t.MaximumStudent);
                var overAllEvaluated = teachers.Sum(t => t.EvaluatedCount);

                return new
                {
                    Id = ep.Id,
                    CycleId = ep.CycleId,
                    Cycle = _mapper.Map<GetCycleDto>(ep.Cycle),
                    InstrumentId = ep.InstrumentId,
                    Instrument = _mapper.Map<GetInstrumentDto>(ep.Instrument),
                    AcademicProgramId = ep.AcademicProgramId,
                    AcademicProgram = (AcademicProgram)null,
                    /*
                    EnrollmentRoleId, CreatedByUserId, CreatedDateTime and other non-essential fields
                    could be re-enabled here if necessary.
                    */
                    StartDateTime = ep.StartDateTime,
                    EndDateTime = ep.EndDateTime,
                    IsPosted = isPostedAll && (overAllEvaluated == overAllStudentCount),
                    Teachers = teachers
                        .Select(t => t.ScheduleTeacher.TeacherUser)
                        .Distinct()
                        .Select(teacherUser =>
                        {
                            var thisTeacher = teachers
                                .Where(t => t.ScheduleTeacher.TeacherUserId == teacherUser.Id)
                                .ToList();

                            var overAllScore = evalRating
                                .Where(er => thisTeacher.Any(t => t.ScheduleTeacher.Id == er.ScheduleTeacherId))
                                .SelectMany(er => er.EvaluationRatingDetails)
                                .Sum(er => er.LikertScaleResponse);

                            var maximumScore = evalRating
                                .Where(er => thisTeacher.Any(t => t.ScheduleTeacher.Id == er.ScheduleTeacherId))
                                .SelectMany(er => er.EvaluationRatingDetails)
                                .Sum(er => er.LikertQuestion.LikertScale);

                            var rating = (overAllScore == 0) ? overAllScore : (overAllScore / maximumScore) * 5;

                            return new
                            {
                                Teacher = _mapper.Map<GetUserOnlyDto>(teacherUser),
                                Rating = rating,
                                HandledSections = thisTeacher
                                    .Select(obj => new
                                    {
                                        Course = new
                                        {
                                            CourseTitle = obj.ScheduleTeacher.Schedule.CurriculumDetail.Course.CourseTitle,
                                            CourseCode = obj.ScheduleTeacher.Schedule.CurriculumDetail.Course.CourseCode,
                                            CreditUnits = obj.ScheduleTeacher.Schedule.CurriculumDetail.Course.CreditUnits
                                        },
                                        Section = obj.ScheduleTeacher.Schedule.GeneratedSection,
                                        EvaluatedCount = obj.EvaluatedCount,
                                        NotEvaluatedCount = obj.NotEvaluatedCount,
                                        StudentsWhoDidNotEvaluate = obj.StudentsWhoDidNotEvaluate
                                    })
                            };
                        })
                        .ToList()
                };
            })
        .OrderByDescending(ep => ep.IsPosted);
        return evaluationPeriod;

    }
}
