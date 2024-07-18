using APPLICATION.Dto.EvaluationPeriod;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationPeriodService:GenericService<EvaluationPeriod, GetEvaluationPeriodDto>, IEvaluationPeriodService
{
    public EvaluationPeriodService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
