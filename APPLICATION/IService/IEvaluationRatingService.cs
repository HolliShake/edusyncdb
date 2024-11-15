using APPLICATION.Dto.EvaluationRating;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEvaluationRatingService:IGenericService<EvaluationRating, GetEvaluationRatingDto>
{
    public Task<object> CreateEvaluationRatingScore(EvaluationRatingGroupDto item);
    public Task<bool> UpdatePostedPostStatusByEvaluationPeriodId(int evaluationPeriodId, bool status);
}
