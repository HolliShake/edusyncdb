using AutoMapper;
using APPLICATION.Dto.EvaluationPeriod;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EvaluationPeriodMapper : Profile
{
    public EvaluationPeriodMapper()
    {
        CreateMap<EvaluationPeriodDto, EvaluationPeriod>();
        CreateMap<EvaluationPeriod, GetEvaluationPeriodDto>();
    }
}
