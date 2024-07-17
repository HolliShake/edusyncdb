
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationPeriodService:GenericService<EvaluationPeriod>, IEvaluationPeriodService
{
    public EvaluationPeriodService(AppDbContext context):base(context)
    {
    }
}
