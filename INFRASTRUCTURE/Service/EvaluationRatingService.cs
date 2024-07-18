using APPLICATION.Dto.EvaluationRating;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EvaluationRatingService:GenericService<EvaluationRating, GetEvaluationRatingDto>, IEvaluationRatingService
{
    public EvaluationRatingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
