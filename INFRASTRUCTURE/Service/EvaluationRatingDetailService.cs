using APPLICATION.Dto.EvaluationRatingDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationRatingDetailService:GenericService<EvaluationRatingDetail, GetEvaluationRatingDetailDto>, IEvaluationRatingDetailService
{
    public EvaluationRatingDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
