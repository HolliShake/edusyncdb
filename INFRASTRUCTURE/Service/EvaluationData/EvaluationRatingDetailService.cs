using AutoMapper;
using APPLICATION.Dto.EvaluationRatingDetail;
using APPLICATION.IService.EvaluationData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EvaluationData;

public class EvaluationRatingDetailService:GenericService<EvaluationRatingDetail, GetEvaluationRatingDetailDto>, IEvaluationRatingDetailService
{
    public EvaluationRatingDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
