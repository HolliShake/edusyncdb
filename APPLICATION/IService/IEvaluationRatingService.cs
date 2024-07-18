using APPLICATION.Dto.EvaluationRating;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEvaluationRatingService:IGenericService<EvaluationRating, GetEvaluationRatingDto>
{
}
