
using APPLICATION.Dto.Enrollment;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EnrollmentService:GenericService<Enrollment, GetEnrollmentDto>, IEnrollmentService
{
    public EnrollmentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByEnrollmentRoleId(int enrollmentRoleId)
    {
        return _mapper.Map<ICollection<GetEnrollmentDto>>(await _dbModel
            .Include(e => e.EnrollmentRole)
            .Where(e => e.EnrollmentRoleId == enrollmentRoleId)
            .ToListAsync());
    }

    public async Task<ICollection<GetEnrollmentDto>> GetEnrollmentsByScheduleId(int scheduleId)
    {
        return _mapper.Map<ICollection<GetEnrollmentDto>>(await _dbModel
            .Include(e => e.EnrollmentRole)
            .Include(e => e.Schedule)
            .Include(e => e.StudentUser)
            .Where(e => e.ScheduleId == scheduleId)
            .ToListAsync());
    }

    public async Task<object> GetEnrollmentsWithScoreByScheduleId(int scheduleId)
    {

        var enrollments = await _dbModel
        .Include(e => e.EnrollmentRole)
        .Include(e => e.Schedule)
            .ThenInclude(s => s.Course)
        .Include(e => e.StudentUser)
        .Include(e => e.GradeBookScores)
            .ThenInclude(gbs => gbs.GradeBookItemDetail)
                .ThenInclude(gbid => gbid.GradeBookItem)
                    .ThenInclude(gbi => gbi.GradingPeriod)
        .Where(e => e.ScheduleId == scheduleId)
        .ToListAsync();

        var result = enrollments.SelectMany(e =>
        {
            var grades = e.GradeBookScores;

            var groupedGrades = grades.GroupBy(g => g.Enrollment.StudentUser)
                .Select(group =>
                {
                    var studentId = group.Key.ReferenceId;
                    var studentName = $"{group.Key.LastName}, {group.Key.FirstName}";

                    var gradingPeriods = group.GroupBy(g => g.GradeBookItemDetail.GradeBookItem.GradingPeriod)
                        .Select(g =>
                        {
                            var gradingPeriodTitle = g.Key.GradingPeriodDescription;
                            var totalWeightedScore = g.Sum(g =>
                                (((g.Score / g.GradeBookItemDetail.MaxScore) * 100)
                                * g.GradeBookItemDetail.Weight)
                                * g.GradeBookItemDetail.GradeBookItem.Weight);

                            return new
                            {
                                GradingPeriod = gradingPeriodTitle,
                                Grade = totalWeightedScore
                            };
                        }).ToList();

                    var finalGrade = gradingPeriods.Any()
                        ? gradingPeriods.Sum(x => x.Grade) / gradingPeriods.Count()
                        : 0;

                    return new
                    {
                        StudentId = studentId,
                        FullName = studentName,
                        YearLevel = e.YearLevel,
                        GradingPeriods = gradingPeriods,
                        Course = e.Schedule.Course,
                        FinalGrade = finalGrade,
                        GradeRemarks = e.GradeRemarks
                    };
                }).ToList();

            return groupedGrades;
        }).ToList();
        // Flatten the result using SelectMany

        return result;
    }
}
