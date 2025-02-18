using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Course;
using APPLICATION.Dto.GradeBookScore;
using APPLICATION.Dto.User;
using APPLICATION.IService.GradeBookData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;

namespace INFRASTRUCTURE.Service.GradeBookData;

public class GradeBookScoreService:GenericService<GradeBookScore, GetGradeBookScoreDto>, IGradeBookScoreService
{
    public GradeBookScoreService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object?> GetEnrolledStudentWithOrWithoutScoreByGradeBookItemDetailsId(int gradeBookItemDetailsId)
    {
        var gradeBookDetails = _dbContext
            .GradeBookItemDetails
            .Include(gid => gid.GradeBookItem)
                .ThenInclude(gi => gi.GradeBook)
            .Where(gid => gid.Id == gradeBookItemDetailsId)
            .FirstOrDefault();

        if (gradeBookDetails == null)
        {
            return null;
        }

        var scores = await _dbModel 
            .Include(gbs => gbs.Enrollment)
            .Include(gbs => gbs.GradeBookItemDetail)
            .Where(gbs => gbs.GradeBookItemDetailId == gradeBookItemDetailsId)
            .ToListAsync();

        var enrolledStudents = _dbContext.Enrollments
                .Include(e => e.StudentUser)
                .Where(e => e.ScheduleId == gradeBookDetails.GradeBookItem.GradeBook.ScheduleId)
                .ToList();

        return enrolledStudents.Select(es => new
        {
            StudentId = es.StudentUser.ReferenceId,
            Student = _mapper.Map<GetUserOnlyDto>(es.StudentUser),
            GradeBookItemDetailsId = gradeBookDetails.Id,
            GradeBookItemDetails = (GradeBookItemDetail) null,
            Score =  (scores.Where(s => s.EnrollmentId == es.Id).FirstOrDefault() != null)
                ? scores.Where(s => s.EnrollmentId == es.Id).FirstOrDefault().Score
                : 0,
            WithScore  = scores.Any(s => s.EnrollmentId == es.Id),
            Remarks = (scores.Where(s => s.EnrollmentId == es.Id).FirstOrDefault() != null)
                ? scores.Where(s => s.EnrollmentId == es.Id).FirstOrDefault().Remarks
                : "",
        });
    }

    public async Task<object?> GiveScoreMultiple(GiveGradeBookScoreGroupDto item)
    {
        var gradeBookDetails = await _dbContext
    .GradeBookItemDetails
    .Include(gid => gid.GradeBookItem)
        .ThenInclude(gi => gi.GradeBook)
    .FirstOrDefaultAsync(gid => gid.Id == item.GradeBookItemDetailsId);

        if (gradeBookDetails == null)
        {
            return null;
        }

        var scores = await _dbModel
            .Include(gbs => gbs.Enrollment)
                .ThenInclude(e => e.StudentUser)
            .Where(gbs => gbs.GradeBookItemDetailId == item.GradeBookItemDetailsId)
            .ToListAsync();

        var enrolledStudents = await _dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Where(e => e.ScheduleId == gradeBookDetails.GradeBookItem.GradeBook.ScheduleId)
            .ToListAsync();

        // Create mapping between StudentId and EnrollmentId to avoid multiple Where lookups
        var enrolledStudentsDict = enrolledStudents
            .ToDictionary(es => es.StudentUser.ReferenceId, es => es);

        // Create Mode
        var createMode = item.GradeBookStudentIdScorePairs
            .Where(studentScore => !scores.Any(score => score.Enrollment.StudentUser.ReferenceId == studentScore.StudentId))
            .Select(studentScore => new GradeBookScore
            {
                GradeBookItemDetailId = item.GradeBookItemDetailsId,
                EnrollmentId = enrolledStudentsDict.TryGetValue(studentScore.StudentId, out var enrollment) ? enrollment.Id : 0,
                Enrollment = enrollment,
                Score = studentScore.Score,
                Remarks = studentScore.Remarks,
            }).ToList();

        // Update Mode
        var updateMode = scores
            .Select(score =>
            {
                var studentScore = item.GradeBookStudentIdScorePairs
                    .FirstOrDefault(ss => ss.StudentId == score.Enrollment.StudentUser.ReferenceId);

                if (studentScore != null)
                {
                    score.Score = studentScore.Score;
                    score.Remarks = studentScore.Remarks;
                }
                return score;
            }).ToList();

        // Bulk insert and update
        if (createMode.Any())
        {
            _dbModel.AddRange(createMode);
        }

        if (updateMode.Any())
        {
            _dbModel.UpdateRange(updateMode);
        }

        // Save changes
        var result = await Save();
        if (!result)
        {
            return null;
        }

        // Combine and return result
        var allItems = createMode.Concat(updateMode).ToList();
        return allItems.Select(score => new
        {
            Id = score.Id,
            StudentId = score.Enrollment.StudentUser.ReferenceId,
            Student = _mapper.Map<GetUserOnlyDto>(score.Enrollment.StudentUser),
            GradeBookItemDetailId = score.GradeBookItemDetailId,
            GradeBookItemDetail = (GradeBookItemDetail)null,
            Score = score.Score,
            WithScore = true,
            Remarks = score.Remarks,
        });

    }

    public async Task<object> GetStudentGradeBookInformationByScheduleAndStudentId(int scheduleId, int studentId)
    {
        if (!_dbContext.Users.Any(u => u.ReferenceId == studentId))
        {
            throw new Error404("Student not found...");
        }

        var gradeBooksScores = await _dbModel
            .Include(gb => gb.Enrollment)
                .ThenInclude(e => e.StudentUser)
            .Include(gb => gb.GradeBookItemDetail)
                .ThenInclude(gbid => gbid.GradeBookItem)
                    .ThenInclude(gbi => gbi.GradingPeriod)
            .Where(gb => gb.Enrollment.StudentUser.ReferenceId == studentId)
            .ToListAsync();

        var modelGradeBook = await _dbContext.GradeBooks
            .Include(gb => gb.GradeBookItems)
                .ThenInclude(gbi => gbi.GradeBookItemDetails)
            .Include(gb => gb.GradeBookItems)
                .ThenInclude(gbi => gbi.GradingPeriod)
            .Where(gb => gb.ScheduleId == scheduleId)
            .FirstOrDefaultAsync();

        if (modelGradeBook == null)
        {
            throw new Error404("GradeBook not found or generated for this schedule...");
        }

        var studentEnrollment = _dbContext.Enrollments.Include(e => e.StudentUser)
                .Include(e => e.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(s => s.Course)
                .Include(e => e.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(s => s.Curriculum)
                            .ThenInclude(c => c.AcademicProgram)
                                .ThenInclude(ap => ap.College)
                                    .ThenInclude(c => c.Campus)
            .Where(e => e.ScheduleId == scheduleId)
            .Where(e => e.StudentUser.ReferenceId == studentId)
            .FirstOrDefault();

        if (studentEnrollment == null)
        {
            throw new Error404("Student not found in this schedule (not enrolled)...");
        }

        var student = studentEnrollment.StudentUser;

        return new
        {
            StudentId = studentId,
            StudentUser = _mapper.Map<GetUserOnlyDto>(student),
            //
            CampusId = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId,
            Campus = new
            {
                Id = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId,
                CampusName = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.CampusName,
                CampusCode = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.Address,
                Longitude = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.Longitude,
                Latitude = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.Campus.Latitude,
            },
            //
            CollegeId = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId,
            College = new
            {
                Id = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.CollegeId,
                CollegeName = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.College.CollegeName
            },
            //
            YearLevel = studentEnrollment.YearLevel,
            //
            AcademicProgramId = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
            AcademicProgram = new
            {
                Id = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
                ProgramName = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                ShortName = studentEnrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgram.ShortName
            },
            //
            CourseId = studentEnrollment.Schedule.CurriculumDetail.CourseId,
            Course = _mapper.Map<GetCourseDto>(studentEnrollment.Schedule.CurriculumDetail.Course),
            //
            GradingPeriods = modelGradeBook.GradeBookItems
            .GroupBy(gbi => gbi.GradingPeriod)
            .Select(gp => new
            {
                Id = gp.Key.Id,
                GradingPeriodDescription = gp.Key.GradingPeriodDescription,
                GradingNumber = gp.Key.GradingNumber,
                CollegeId = gp.Key.CollegeId,
                College = gp.Key.College,
                IsPosted = _dbContext.EnrollmentGrades
                    .Where(eg => eg.GradingPeriodId == gp.Key.Id)
                    .Where(eg => eg.EnrollmentId == studentEnrollment.Id)
                    .Where(eg => eg.IsPosted)
                    .Any(),
                GradeBookItems = modelGradeBook.GradeBookItems
                    .Where(gbi => gbi.GradingPeriodId == gp.Key.Id)
                    .Select(gbi => new
                    {
                        Id = gbi.Id,
                        ItemName = gbi.ItemName,
                        GradeBookId = gbi.GradeBookId,
                        GradeBook = (GradeBook) null,
                        GradingPeriodId = gbi.GradingPeriodId,
                        GradingPeriod = (GradingPeriod) null,
                        Weight = gbi.Weight,
                        GradeBookItemDetails = gbi.GradeBookItemDetails.Select(gbid =>
                            {
                                var hasAny = gradeBooksScores.Any(gbs => gbs.GradeBookItemDetailId == gbid.Id);
                                var result = gradeBooksScores
                                    .Where(gbs => gbs.GradeBookItemDetailId == gbid.Id)
                                    .FirstOrDefault();

                                return new
                                {
                                    Id = gbid.Id,
                                    ItemDetail = gbid.ItemDetail,
                                    ItemDetailDescription = gbid.ItemDetailDescription,
                                    MaxScore = gbid.MaxScore,
                                    PassingScore = gbid.PassingScore,
                                    Weight = gbid.Weight,
                                    GradeBookItemId = gbid.GradeBookItemId,
                                    GradeBookItem = (GradeBookItem) null,
                                    EqaAssessmentTypeId = gbid.EqaAssessmentTypeId,
                                    EqaAssessmentType = gbid.EqaAssessmentType,
                                    Score = (object) ((result != null)
                                    ? new
                                    {
                                        Id = result.Id,
                                        EnrollmentId = result.EnrollmentId,
                                        Enrollment = (Enrollment) null,
                                        GradeBookItemDetailId = gbid.Id,
                                        GradeBookItemDetail = (GradeBookItemDetail) null,
                                        Score = result.Score,
                                    }
                                    : new
                                    {
                                        Id = 0,
                                        EnrollmentId = studentEnrollment.Id,
                                        Enrollment = (Enrollment) null,
                                        GradeBookItemDetailId = gbid.Id,
                                        GradeBookItemDetail = (GradeBookItemDetail) null,
                                        Score = 0,
                                    })
                                };
                            })
                    })
            })
        };
    }

    public async Task<bool> HasAnyScoreByEnrollmentAndGradeBookItemDetailsId(int enrollmentId, int gradeBookItemDetailId)
    {
        return await _dbModel
            .AnyAsync(gbs => gbs.EnrollmentId == enrollmentId && gbs.GradeBookItemDetailId == gradeBookItemDetailId);
    }

    public async Task<GetGradeBookScoreDto?> DefaultScoreByEnrollmentAndGradeBookItemDetailsIdOrNone(int enrollmentId, int gradeBookItemDetailId, int scoreId)
    {
        var result = (await HasAnyScoreByEnrollmentAndGradeBookItemDetailsId(enrollmentId, gradeBookItemDetailId))
            ? _mapper.Map<GetGradeBookScoreDto>(await _dbModel
                .Include(gbs => gbs.Enrollment)
                .Include(gbs => gbs.GradeBookItemDetail)
                .Where(gbs => gbs.EnrollmentId == enrollmentId)
                .Where(gbs => gbs.GradeBookItemDetailId == gradeBookItemDetailId)
                .FirstOrDefaultAsync())
            : _mapper.Map<GetGradeBookScoreDto>(await GetAsync(scoreId));
        return result;
    }
}
