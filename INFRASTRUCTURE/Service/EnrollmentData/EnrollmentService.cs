using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Enrollment;
using APPLICATION.IService.EnrollmentData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EnrollmentData;

public class EnrollmentService:GenericService<Enrollment, GetEnrollmentDto>, IEnrollmentService
{
    public EnrollmentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<bool> IsStudent(string userId)
    {
        return await _dbModel.AnyAsync(e => e.StudentUserId == userId);
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId)
    {
        var enrollments = await _dbModel
            .Include(e => e.EnrollmentRole)
            .Where(e => e.EnrollmentRoleId == enrollmentRoleId)
            .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentDto>>(enrollments);
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByScheduleId(int scheduleId)
    {
        var enrollments = await _dbModel
        .Include(e => e.EnrollmentRole)
        .Include(e => e.Schedule)
        .Include(e => e.StudentUser)
        .Where(e => e.ScheduleId == scheduleId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentDto>>(enrollments);
    }

    public async Task<object> GetEnrollmentsWithScoreByScheduleId(int scheduleId)
    {
        var enrollments = await _dbModel
        .Include(e => e.EnrollmentRole)
        .Include(e => e.Schedule)
            .ThenInclude(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
        .Include(e => e.StudentUser)
        .Include(e => e.GradeBookScores)
            .ThenInclude(gbs => gbs.GradeBookItemDetail)
                .ThenInclude(gbid => gbid.GradeBookItem)
                    .ThenInclude(gbi => gbi.GradingPeriod)
        .Where(e => e.ScheduleId == scheduleId)
        .ToListAsync();

        var gradeBook = _dbContext.GradeBooks
                .Include(gb => gb.GradeBookItems)
                    .ThenInclude(gbi => gbi.GradingPeriod)
                .Where(gb => gb.ScheduleId == scheduleId)
                .SingleOrDefault();

        if (gradeBook == null)
        {
            return (List<object>) [];
        }

        var result = enrollments.Select(e =>
        {
            var studentId = e.StudentUser.ReferenceId;
            var studentName = $"{e.StudentUser.LastName}, {e.StudentUser.FirstName}";
            var grades = e.GradeBookScores;

            var gradingPeriods = Utility.CalculatePerGradingPeriod([.. grades]);
            var finalGrade = Utility.CalculateFinalGrade(gradingPeriods);

            return new
            {
                ScheduleId = scheduleId,
                StudentId = studentId,
                FullName = studentName,
                YearLevel = e.YearLevel,
                GradingPeriods = gradeBook.GradeBookItems
                .Select(gbi => gbi.GradingPeriod)
                .Distinct()
                .Select(gp =>
                {
                    var grade = (decimal)(gradingPeriods
                        .Where(gpws => gpws.GradingPeriodId == gp.Id)
                        .Select(gpws => gpws.Grade)
                        .FirstOrDefault());
                    return new
                    {
                        Id = gp.Id,
                        GradingPeriod = gp.GradingPeriodDescription,
                        Grade = grade,
                        GradeInput = _dbContext.GradeInputs.Where(gi => grade >= gi.StartRange && grade <= gi.EndRange).FirstOrDefault()
                    };
                }),
                Course = e.Schedule.CurriculumDetail.Course,
                FinalGrade = finalGrade,
                GradeRemarks = e.GradeRemarks
            };
        });

        // Flatten the result using SelectMany

        var gradingPeriods = gradeBook.GradeBookItems
                .Select(gbi => gbi.GradingPeriod)
                .Distinct()
                .Select(gp =>
                {
                    var postedCount = _dbContext
                        .EnrollmentGrades
                        .Include(eg => eg.Enrollment)
                        .Where(eg => eg.Enrollment.ScheduleId == scheduleId)
                        .Where(eg => eg.GradingPeriodId == gp.Id)
                        .Where(eg => eg.IsPosted)
                        .Count();

                    return (new
                    {
                        GradingPeriodId = gp.Id,
                        GradingPeriod = gp.GradingPeriodDescription,
                        IsPosted = (postedCount == result.Count())
                    });
                });

        return (new
        {
            GradingPeriods = gradingPeriods,
            Enrollments = result
        });
    }

    public async Task<object> GetEnrollmentsByStudentUserId(string userId)
    {
        var enrollments = await _dbModel
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(s => s.Course)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicTerm)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.Teachers)
                    .ThenInclude(t => t.TeacherUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.ScheduleAssignments)
            .Where(e => e.StudentUser.Id == userId)
            .OrderBy(e => e.Id)
            .OrderBy(e => e.YearLevel)
            .OrderBy(e => e.Schedule.CurriculumDetail.TermNumber)
            .GroupBy(e => e.YearLevel)
            .Select(e => new
            {
                YearLevel = $"{Utility.AddSuffix(e.Key)} Year",
                AcademicTerms = e
                    .GroupBy(e1 => e1.Schedule.CurriculumDetail.TermNumber)
                    .Select(e1 => new
                    {
                        TermName = $"{Utility.AddSuffix(e1.Key)} {e1.First().Schedule.CurriculumDetail.Curriculum.AcademicTerm.Label}",
                        CoursesEnrolled = e1.Select(e1 => new
                        {
                            CourseTitle = e1.Schedule.CurriculumDetail.Course.CourseTitle,
                            CourseCode = e1.Schedule.CurriculumDetail.Course.CourseCode,
                            CourseDescription = e1.Schedule.CurriculumDetail.Course.CourseDescription,
                            LectureUnits = e1.Schedule.CurriculumDetail.Course.LectureUnits,
                            LaboratoryUnits = e1.Schedule.CurriculumDetail.Course.LaboratoryUnits,
                            CreditUnits = e1.Schedule.CurriculumDetail.Course.CreditUnits,
                            Requisites = e1.Schedule.CurriculumDetail.Course.CourseRequisites.Select(cr => new
                            {
                                CourseTitle = cr.Course.CourseTitle,
                                CourseCode = cr.Course.CourseCode,
                                CourseDescription = cr.Course.CourseDescription
                            }),
                            Schedules = e1.Schedule.ScheduleAssignments.Select(sa => new
                            {
                                Id = sa.Id,
                                RoomId = sa.RoomId,
                                Room = sa.Room,
                                DaySchedule = sa.DaySchedule,
                                TimeScheduleIn = sa.TimeScheduleIn,
                                TimeScheduleOut = sa.TimeScheduleOut,
                            }),
                            Teachers = e1.Schedule.Teachers.Select(t => new
                            {
                                TeacherId = t.TeacherUser.Id,
                                TeacherName = $"{t.TeacherUser.LastName}, {t.TeacherUser.FirstName}"
                            })
                        }).ToList()
                    }).ToList()
            })
            .ToListAsync();

        return enrollments;
    }

    public async Task<object> GetUserTodaysScheduleIfEnrolled(string userId)
    {
        var today = await _dbModel.Where(e => e.StudentUserId == userId)
                .Include(e => e.Schedule)
                    .ThenInclude(s => s.ScheduleAssignments)
                        .ThenInclude(sa => sa.Room)
                            .ThenInclude(r => r.Building)
                .Include(e => e.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Course)
                .AsNoTracking()
                .ToListAsync();

        var schedules = today.SelectMany(e => e.Schedule.ScheduleAssignments)
            .Where(sa =>
            {
                var now = DateTime.Now;
                return sa.DaySchedule.Year == now.Year && sa.DaySchedule.DayOfWeek == now.DayOfWeek;
            })
            .Select(sa =>
            {
                return new
                { 
                    Id = sa.Id,
                    //
                    DaySchedule = sa.DaySchedule,
                    TimeScheduleIn = sa.TimeScheduleIn,
                    TimeScheduleOut = sa.TimeScheduleOut,
                    //
                    BuildingId = sa.Room.BuildingId,
                    Building = new
                    {
                        sa.Room.Building.Id,
                        sa.Room.Building.BuildingName,
                    },
                    //
                    RoomId = sa.RoomId,
                    Room = new
                    {
                        Id = sa.Room.Id,
                        RoomName = sa.Room.RoomName,
                        IsLab = sa.Room.IsLab,
                        IsEspecializedLab = sa.Room.IsEspecializedLab
                    },
                    //
                    CourseId = sa.Schedule.CurriculumDetail.CourseId,
                    Course = new
                    {
                        Id = sa.Schedule.CurriculumDetail.Course.Id,
                        CourseTitle = sa.Schedule.CurriculumDetail.Course.CourseTitle,
                        CourseCode = sa.Schedule.CurriculumDetail.Course.CourseCode,
                        CourseDescription = sa.Schedule.CurriculumDetail.Course.CourseDescription,
                    },
                    //
                    Info = new
                    {
                        Ongoing = 
                            (DateTime.Now.TimeOfDay >= sa.TimeScheduleIn.TimeOfDay  && DateTime.Now.TimeOfDay <= sa.TimeScheduleOut.TimeOfDay)
                    }
                };
            });

        return schedules;
    }

}
