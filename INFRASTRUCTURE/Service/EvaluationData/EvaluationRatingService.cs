using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.EvaluationRating;
using APPLICATION.IService.EvaluationData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;

namespace INFRASTRUCTURE.Service.EvaluationData;

public class EvaluationRatingService:GenericService<EvaluationRating, GetEvaluationRatingDto>, IEvaluationRatingService
{
    public EvaluationRatingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> CreateEvaluationRatingScore(EvaluationRatingGroupDto item)
    {
        // Validate EnrollmentId
        var enrollment = await _dbContext.Enrollments.AnyAsync(e => e.Id == item.EnrollmentId);
        if (!enrollment)
        {
            throw new Error404("Invalid EnrollmentId...");
        }

        // Validate EvaluationPeriodId
        var evaluationPeriod = await _dbContext.EvaluationPeriods.AnyAsync(ep => ep.Id == item.EvaluationPeriodId);
        if (!evaluationPeriod)
        {
            throw new Error404("Invalid EvaluationPeriodId...");
        }


        // Check if evaluated already
        var evaluated = _dbModel
            .Where(er => er.EnrollmentId == item.EnrollmentId)
            .Where(er => er.ScheduleTeacherId == item.ScheduleTeacherId)
            .Where(er => er.EvaluationPeriodId == item.EvaluationPeriodId)
            .Any();

        if (evaluated)
        {
            throw new Error400("Evaluation has been already submitted...");
        }

        var evaluationRating = new EvaluationRating
        {
            EnrollmentId = item.EnrollmentId,
            EvaluationPeriodId = item.EvaluationPeriodId,
            IsPosted = false,
            OverallComment = item.OverAllComment,
            RatingDateTime = DateTime.Now,
            ScheduleTeacherId = item.ScheduleTeacherId
        };
        GetEvaluationRatingDto eval;
        if ((eval = await CreateAsync(evaluationRating)) == null)
        {
            throw new Error400("Failed to create evaluation rating...");
        }

        var evaluationRatingDetails = item.EvaluationRatingDetails.Select(erd => new EvaluationRatingDetail
        {
            EvaluationRatingId = eval.Id,
            LikertQuestionId = erd.LikertQuestionId,
            LikertScaleResponse = erd.LikertScaleResponse,
            QuestionTextResponse = erd.QuestionTextResponse
        });

        _dbContext.EvaluationRatingDetails.AddRange(evaluationRatingDetails);

        if (!await Save())
        {
            throw new Error400("Failed to create evaluation rating details...");
        }

        return (new
        {
            evaluationRating.Id,
            evaluationRating.EnrollmentId,
            evaluationRating.Enrollment,
            evaluationRating.EvaluationPeriodId,
            evaluationRating.EvaluationPeriod,
            evaluationRating.RatingDateTime,
            evaluationRating.IsPosted,
            evaluationRating.ScheduleTeacherId,
            evaluationRating.ScheduleTeacher,
            EvaluationRatingDetails = evaluationRatingDetails,
            evaluationRating.OverallComment
        });
    }

    public async Task<bool> UpdatePostedPostStatusByEvaluationPeriodId(int evaluationPeriodId, bool status)
    {
        var update = await _dbModel
        .Where(er => er.EvaluationPeriodId == evaluationPeriodId)
        .ExecuteUpdateAsync(er => er.SetProperty(e => e.IsPosted, status));
        return update > 0;
    }
}
