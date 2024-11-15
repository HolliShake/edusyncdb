using APPLICATION.Dto.Course;
using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.EvaluationPeriod;
using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.User;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EvaluationPeriodService:GenericService<EvaluationPeriod, GetEvaluationPeriodDto>, IEvaluationPeriodService
{
    public EvaluationPeriodService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> GetAllEvaluationTeachsByEvaluationPeriodAndUserId(string userId, int evaluationPeriodId)
    {
        var evaluationPeriod = await _dbModel
            .Include(ep => ep.EvaluationRatings)
            .Include(ep => ep.Instrument)
                .ThenInclude(i => i.ParameterCategories)
                    .ThenInclude(pc => pc.ParameterSubCategories)
                        .ThenInclude(psc => psc.Parameters)
                            .ThenInclude(p => p.LikertQuestions)
            .Where(ep => ep.Id == evaluationPeriodId)
            .SingleOrDefaultAsync();

        if (evaluationPeriod == null)
        {
            return null;
        }

        var unEvaluatedTeachers = (_dbContext.Enrollments
            .Include(e => e.StudentUser)
            .Include(e => e.Schedule)
               .ThenInclude(s => s.Teachers)
                    .ThenInclude(t => t.TeacherUser)
            .Include(e => e.Schedule)
                .ThenInclude(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
            .Where(e => e.StudentUserId == userId)
            .ToList())
            .Where(e => !evaluationPeriod.EvaluationRatings.Any(er => er.EnrollmentId == e.Id))
            .ToList();

        List<object> items = [];
        foreach (var item in unEvaluatedTeachers)
        {
            foreach (var item1 in item.Schedule.Teachers)
            {
                items.Add(new
                {   
                    EvaluationPeriodId = evaluationPeriod.Id,
                    EvaluationPeriod = (EvaluationPeriod) null,
                    EnrollmentId = item.Id,
                    Enrollment = (Enrollment) null,
                    ScheduleTeacherId = item1.Id,
                    ScheduleTeacher = (ScheduleTeacher) null,
                    TeacherUserId = item1.TeacherUserId,
                    TeacherUser = _mapper.Map<GetUserOnlyDto>(item1.TeacherUser),
                    ScheduleId = item1.ScheduleId,
                    Schedule = (new
                    {
                        item1.Schedule.Id,
                        item1.Schedule.GeneratedReference,
                        item1.Schedule.GeneratedSection
                    }),
                    CourseId = item.Schedule.CurriculumDetail.CourseId,
                    Course = (new
                    {
                        item.Schedule.CurriculumDetail.Course.Id,
                        item.Schedule.CurriculumDetail.Course.CourseTitle,
                        item.Schedule.CurriculumDetail.Course.CourseCode,
                        item.Schedule.CurriculumDetail.Course.CourseDescription
                    })
                });
            }
        }
        return items;
    }

    public async Task<object?> GetEvaluationPeriodInformation(int id)
    {
        var evaluationPeriod = await _dbModel
            .Include(ep => ep.EvaluationRatings)
                .ThenInclude(er => er.EvaluationRatingDetails)
                    .ThenInclude(er => er.LikertQuestion)
            .Include(ep => ep.Instrument)
                .ThenInclude(i => i.ParameterCategories)
                    .ThenInclude(pc => pc.ParameterSubCategories)
                        .ThenInclude(psc => psc.Parameters)
                            .ThenInclude(p => p.LikertQuestions)
            .Where(ep => ep.Id == id)
            .SingleOrDefaultAsync();

        if (evaluationPeriod == null)
        {
            return null;
        }

        return new
        {
            Id = evaluationPeriod.Id,
            StartDateTime = evaluationPeriod.StartDateTime,
            EndDateTime = evaluationPeriod.EndDateTime,
            IsOpenOverride = evaluationPeriod.IsOpenOverride,
            IsEnabled = evaluationPeriod.IsEnabled,
            EnrollmentRoleId = evaluationPeriod.EnrollmentRoleId,
            Legends = evaluationPeriod.Instrument.ParameterCategories
                .SelectMany(i => i.ParameterSubCategories)
                .SelectMany(psc => psc.Parameters)
                .SelectMany(p => p.LikertQuestions)
                .ToList()
                .GroupBy(lq => lq.Parameter.QuestionTypeLikertOrText)
                .Select(lq => lq.Select(types => new
                {
                    LikertScale = types.LikertScale,
                    QuestionText = types.QuestionText,
                }).Distinct().ToList())
                .ToList(),
            Instrument = new
            {
                Id = evaluationPeriod.Instrument.Id,
                Name = evaluationPeriod.Instrument.Name,
                Description = evaluationPeriod.Instrument.Description,
                NumberOfChoices = evaluationPeriod.Instrument.NumberOfChoices,
                IsEnabled = evaluationPeriod.Instrument.IsEnabled,
                ParameterCategories = evaluationPeriod.Instrument.ParameterCategories.Select(pc => new
                {
                    Id = pc.Id,
                    ParameterCategoryName = pc.ParameterCategoryName,
                    ParameterSubCategories = pc.ParameterSubCategories.Select(psc => new
                    {
                        Id = psc.Id,
                        ParameterSubCategoryName = psc.ParameterSubCategoryName,
                        Parameters = psc.Parameters.Select(p => new
                        {
                            Id = p.Id,
                            ParameterName = p.ParameterName,
                            QuestionTypeLikertOrText = p.QuestionTypeLikertOrText,
                            ParentId = p.ParentId,
                            LikertQuestions = p.LikertQuestions.Select(lq => new
                            {
                                Id = lq.Id,
                                QuestionText = lq.QuestionText,
                                LikertScale = lq.LikertScale,
                                IsEnabled = lq.IsEnabled,
                                IsVisible = lq.IsVisible,
                                ParameterId = lq.ParameterId
                            }).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList()
            }
        };
    }

    public async Task<object> GetOpenEvaluationPeriodByEnrollmentUserId(string userId)
    {
        var enrollments = (await _dbContext.Enrollments
        .Include(e => e.StudentUser)
        .Include(e => e.Schedule)
            .ThenInclude(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
        .Where(e => e.StudentUserId == userId)
        .Distinct()
        .ToListAsync());

        return enrollments.Select(enrollment =>
        {
            var evaluationPeriod = _dbModel
                .Include(ep => ep.Instrument)
                .Include(ep => ep.Cycle)
                .Include(ep => ep.AcademicProgram)
                .Include(ep => ep.EvaluationRatings)
                .Where(ep =>
                    ep.EnrollmentRoleId == enrollment.EnrollmentRoleId &&
                    ((ep.StartDateTime <= DateTime.Now && ep.EndDateTime >= DateTime.Now && ep.IsEnabled) || ep.IsOpenOverride) &&
                    ep.CycleId == enrollment.Schedule.CycleId &&
                    ep.AcademicProgramId == enrollment.Schedule.CurriculumDetail.Curriculum.AcademicProgramId &&
                    !ep.EvaluationRatings.Any(er => er.EnrollmentId == enrollment.Id))
                .FirstOrDefault();

            return evaluationPeriod == null ? null : new
            {
                Id = evaluationPeriod.Id,
                CreatedDateTime = evaluationPeriod.CreatedDateTime,
                StartDateTime = evaluationPeriod.StartDateTime,
                EndDateTime = evaluationPeriod.EndDateTime,
                IsOpenOverride = evaluationPeriod.IsOpenOverride,
                IsEnabled = evaluationPeriod.IsEnabled,
                InstrumentId = evaluationPeriod.InstrumentId,
                Instrument = evaluationPeriod.Instrument,
                AcademicProgramId = evaluationPeriod.AcademicProgramId,
                AcademicProgram = evaluationPeriod.AcademicProgram,
                CycleId = evaluationPeriod.CycleId,
                Cycle = evaluationPeriod.Cycle,
                CreatedByUserId = evaluationPeriod.CreatedByUserId,
                CreatedByUser = evaluationPeriod.CreatedByUser
            };
        })
        .Where(evp => evp != null)
        .ToList();
    }
}
