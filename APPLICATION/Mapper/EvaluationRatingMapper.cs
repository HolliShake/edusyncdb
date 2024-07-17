using AutoMapper;
using APPLICATION.Dto.EvaluationRating;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EvaluationRatingMapper : Profile
{
    public EvaluationRatingMapper()
    {
        CreateMap<EvaluationRatingDto, EvaluationRating>();
        CreateMap<EvaluationRating, GetEvaluationRatingDto>();
    }
}
