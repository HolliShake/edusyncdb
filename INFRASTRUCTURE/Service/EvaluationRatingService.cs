
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationRatingService:GenericService<EvaluationRating>, IEvaluationRatingService
{
    public EvaluationRatingService(AppDbContext context):base(context)
    {
    }
}
