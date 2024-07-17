using AutoMapper;
using APPLICATION.Dto.EvaluationRatingDetail;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EvaluationRatingDetailMapper : Profile
{
    public EvaluationRatingDetailMapper()
    {
        CreateMap<EvaluationRatingDetailDto, EvaluationRatingDetail>();
        CreateMap<EvaluationRatingDetail, GetEvaluationRatingDetailDto>();
    }
}
