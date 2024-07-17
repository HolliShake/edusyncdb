
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationRatingDetailService:GenericService<EvaluationRatingDetail>, IEvaluationRatingDetailService
{
    public EvaluationRatingDetailService(AppDbContext context):base(context)
    {
    }
}
