using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.EnrollmentGrade;
using APPLICATION.IService.EnrollmentData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EnrollmentData;

public class EnrollmentGradeService:GenericService<EnrollmentGrade, GetEnrollmentGradeDto>, IEnrollmentGradeService
{
    public EnrollmentGradeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> GetPostedGradesByStudentUserId(string userId)
    {
        var postedEnrollmentGrades = await _dbModel
        .Include(eg => eg.Enrollment)
            .ThenInclude(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
        .Include(eg => eg.Enrollment)
            .ThenInclude(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicTerm)
        .Include(eg => eg.GradingPeriod)
        .Include(eg => eg.GradeInput)
        .Where(eg => eg.IsPosted)
        .Where(eg => eg.Enrollment.StudentUserId == userId)
        .ToListAsync();

        return postedEnrollmentGrades
            .OrderBy(eg => eg.Enrollment.YearLevel)
            .ThenBy(eg => eg.Enrollment.Schedule.CurriculumDetail.TermNumber)
            .GroupBy(eg => eg.Enrollment.YearLevel)
            .Select(eg => new
            {
                YearLevel = $"{Utility.AddSuffix(eg.Key)} Year",
                Terms = eg
                    .GroupBy(eg => eg.Enrollment.Schedule.CurriculumDetail.TermNumber)
                    .Select(termGroup => new
                    {
                        TermName = $"{Utility.AddSuffix(termGroup.Key)} {termGroup.First().Enrollment.Schedule.CurriculumDetail.Curriculum.AcademicTerm.Label}",
                        Courses = termGroup
                            .Select(eg =>
                            {
                                var gradeBook = _dbContext.GradeBooks
                                    .Include(gb => gb.GradeBookItems)
                                        .ThenInclude(gbi => gbi.GradingPeriod)
                                    .Where(gb => gb.ScheduleId == eg.Enrollment.ScheduleId)
                                    .SingleOrDefault();

                                return new
                                {
                                    CourseId = eg.Enrollment.Schedule.CurriculumDetail.CourseId,
                                    CourseTitle = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseTitle,
                                    CourseCode = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseCode,
                                    CourseDescription = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseDescription,
                                    CreditUnits = eg.Enrollment.Schedule.CurriculumDetail.Course.CreditUnits,
                                    Section = eg.Enrollment.Schedule.GeneratedSection,
                                    GradingPeriods = (gradeBook == null) ? [] : gradeBook
                                    .GradeBookItems
                                    .Select(gbi => gbi.GradingPeriod)
                                    .Distinct()
                                    .Select(gp =>
                                    {
                                        var grades = _dbContext.GradeBookScores
                                            .Include(gbs => gbs.GradeBookItemDetail)
                                                .ThenInclude(gbid => gbid.GradeBookItem)
                                                    .ThenInclude(gbi => gbi.GradingPeriod)
                                            .Include(gbs => gbs.GradeBookItemDetail)
                                                .ThenInclude(gbid => gbid.GradeBookItem)
                                                    .ThenInclude(gbi => gbi.GradeBook)
                                            .Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradingPeriodId == gp.Id)
                                            .Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradingPeriodId == eg.GradingPeriodId)
                                            .Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradeBook.ScheduleId == eg.Enrollment.ScheduleId)
                                            .ToList();

                                        /*
                                        var totalWeightedScore = grades.Sum(g =>
                                            (((g.Score / g.GradeBookItemDetail.MaxScore) * 100)
                                            * g.GradeBookItemDetail.Weight)
                                            * g.GradeBookItemDetail.GradeBookItem.Weight);
                                        */

                                        var gradingPeriods = Utility.CalculatePerGradingPeriod(grades);
                                        var grade = (decimal) ((gradingPeriods.Count > 0)
                                            ? gradingPeriods.Where(item => item.GradingPeriodId == gp.Id).SingleOrDefault().Grade
                                            : 0);

                                        return new
                                        {
                                            GradingPeriodDescription = gp.GradingPeriodDescription,
                                            Grade = grade,
                                            GradeInput = _dbContext.GradeInputs.Where(gi => grade >= gi.StartRange && grade <= gi.EndRange).FirstOrDefault(),
                                        };
                                    }),
                                    GradeStatus = eg.GradeStatus,
                                    GradeNotes = eg.GradeNotes,
                                };
                            })
                            .GroupBy(c => c.CourseId)  // Group by CourseId to filter duplicates
                            .Select(g => g.First())     // Select first entry from each course group
                    })
            });
    }
    public async Task<object> GetAssessmentsByStudentUserId(string userId)
    {
        var postedEnrollmentGrades = await _dbModel
            .Include(eg => eg.Enrollment)
                .ThenInclude(e => e.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Course)
                            .ThenInclude(c => c.CourseRequisites)
            .Include(eg => eg.Enrollment)
                .ThenInclude(e => e.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Curriculum)
                            .ThenInclude(c => c.AcademicTerm)
            .Include(eg => eg.GradingPeriod)
            .Include(eg => eg.GradeInput)
            .Where(eg => eg.IsPosted)
            .Where(eg => eg.Enrollment.StudentUserId == userId)
            .ToListAsync();

        return postedEnrollmentGrades
            .OrderBy(eg => eg.Enrollment.YearLevel)
            .ThenBy(eg => eg.Enrollment.Schedule.CurriculumDetail.TermNumber)
            .GroupBy(eg => eg.Enrollment.YearLevel)
            .Select(eg => new
            {
                YearLevel = $"{Utility.AddSuffix(eg.Key)} Year",
                Terms = eg
                    .GroupBy(eg => eg.Enrollment.Schedule.CurriculumDetail.TermNumber)
                    .Select(termGroup => new
                    {
                        TermName = $"{Utility.AddSuffix(termGroup.Key)} {termGroup.First().Enrollment.Schedule.CurriculumDetail.Curriculum.AcademicTerm.Label}",
                        Courses = termGroup
                            .Select(eg => new
                            {
                                CourseId = eg.Enrollment.Schedule.CurriculumDetail.CourseId,
                                CourseTitle = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseTitle,
                                CourseCode = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseCode,
                                CourseDescription = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseDescription,
                                CreditUnits = eg.Enrollment.Schedule.CurriculumDetail.Course.CreditUnits,
                                Requisites = eg.Enrollment.Schedule.CurriculumDetail.Course.CourseRequisites.Select(cr => new
                                {
                                    CourseTitle = cr.Course.CourseTitle,
                                    CourseCode = cr.Course.CourseCode,
                                    CourseDescription = cr.Course.CourseDescription
                                })
                            })
                            .GroupBy(c => c.CourseId)  // Group by CourseId to filter duplicates
                            .Select(g => g.First()),   // Select first entry from each course group
                        TotalCredit = termGroup.Sum(eg => eg.Enrollment.Schedule.CurriculumDetail.Course.CreditUnits)
                    })
            });
    }

    public async Task<object?> PostOrUnPostGrade(int enrollmentId, int gradingPeriodId, string userId, bool post)
    {
        var posted = await _dbModel
            .Include(eg => eg.Enrollment)
            .Where(eg => eg.EnrollmentId == enrollmentId)
            .Where(eg => eg.GradingPeriodId == gradingPeriodId)
            .SingleOrDefaultAsync();

        var enrollment = await _dbContext.Enrollments
            .Include(e => e.GradeBookScores)
                .ThenInclude(gbs => gbs.GradeBookItemDetail)
                    .ThenInclude(gbs => gbs.GradeBookItem)
                        .ThenInclude(gbs => gbs.GradingPeriod)
            .Where(e => e.Id == enrollmentId)
            .SingleOrDefaultAsync();

        if (enrollment == null)
        {
            return null;
        }

        var finalGrade = Utility.CalculateFinalGrade(enrollment.GradeBookScores.Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradingPeriodId == gradingPeriodId).ToList());
        var gradeInput = _dbContext.GradeInputs
            .Where(gi => (finalGrade >= gi.StartRange && finalGrade <= gi.EndRange))
            .FirstOrDefault();

        if (posted == null)
        {
            // Not yet posted
            // | Create new EnrollmentGrade
            // ;
            var item = new EnrollmentGrade
            {
                EnrollmentId = enrollmentId,
                GradingPeriodId = gradingPeriodId,
                GradeInputId = gradeInput?.Id,
                GradeInput = gradeInput,
                EncodedByUserId = userId,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                IsPosted = post,
                GradeNotes = "N/A",
                GradeStatus = "N/A"
            };
            return await CreateAsync(item);
        }

        posted.IsPosted = post;
        posted.UpdatedDateTime = DateTime.Now;
        posted.GradeInputId = gradeInput?.Id ?? posted.GradeInputId;
        posted.GradeInput = gradeInput;

        return await UpdateAsync(posted);
    }

    public async Task<object?> PostOrUnPostGradeByScheduleId(int scheduleId, int gradingPeriodId, string userId, bool post)
    {
        var enrolledUsers = await _dbContext.Enrollments
            .Include(s => s.GradeBookScores)
                .ThenInclude(gbs => gbs.GradeBookItemDetail)
                    .ThenInclude(gbs => gbs.GradeBookItem)
                        .ThenInclude(gbs => gbs.GradingPeriod)
            .Where(s => s.ScheduleId == scheduleId)
            .ToListAsync();

        var enrollmentGradesCreate = enrolledUsers
            .Where(eu => !(_dbModel.Where(eg => eg.EnrollmentId == eu.Id).Where(eg => eg.GradingPeriodId == gradingPeriodId).Any()))
            .Select(eu =>
            {
                var finalGrade = Utility.CalculateFinalGrade(eu.GradeBookScores.Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradingPeriodId == gradingPeriodId).ToList());
                var gradeInput = _dbContext.GradeInputs
                    .Where(gi => (finalGrade >= gi.StartRange && finalGrade <= gi.EndRange))
                    .FirstOrDefault();

                return (new EnrollmentGrade
                {
                    EnrollmentId = eu.Id,
                    GradingPeriodId = gradingPeriodId,
                    GradeInputId = gradeInput?.Id,
                    GradeInput = gradeInput,
                    EncodedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    UpdatedDateTime = DateTime.Now,
                    IsPosted = post,
                    GradeNotes = "N/A",
                    GradeStatus = "N/A"
                });
            })
            .ToList();

        var enrollmentGradesUpdate = enrolledUsers
            .Where(eu => _dbModel.Where(eg => eg.EnrollmentId == eu.Id).Where(eg => eg.GradingPeriodId == gradingPeriodId).Any())
            .Select(eu =>
            {
                var result = _dbModel
                    .Where(eg => eg.EnrollmentId == eu.Id)
                    .Where(eg => eg.GradingPeriodId == gradingPeriodId)
                    .SingleOrDefault();

                var finalGrade = Utility.CalculateFinalGrade(eu.GradeBookScores.Where(gbs => gbs.GradeBookItemDetail.GradeBookItem.GradingPeriodId == gradingPeriodId).ToList());
                var gradeInput = _dbContext.GradeInputs
                    .Where(gi => (finalGrade >= gi.StartRange && finalGrade <= gi.EndRange))
                    .FirstOrDefault();

                if (result != null)
                {
                    result.IsPosted = post;
                    result.UpdatedDateTime = DateTime.Now;
                    result.GradeInputId = gradeInput?.Id ?? result.GradeInputId;
                    result.GradeInput = gradeInput;
                }
                return result;
            })
            .Where(eu => eu != null)
            .ToList();

        List<GetEnrollmentGradeDto> items = [];

        if (enrollmentGradesCreate.Count > 0)
        {
            var createResult = await CreateAllAsync(enrollmentGradesCreate);
            if (createResult != null) {
                items.AddRange(createResult);
            }
        }

        if (enrollmentGradesUpdate.Count > 0)
        {
            _dbModel.UpdateRange(enrollmentGradesUpdate);
            if (await Save()) {
                items.AddRange(_mapper.Map<ICollection<GetEnrollmentGradeDto>>(enrollmentGradesUpdate));
            }
        }
        return items;
    }
}
