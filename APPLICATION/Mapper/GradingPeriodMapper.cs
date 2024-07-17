using AutoMapper;
using APPLICATION.Dto.GradingPeriod;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradingPeriodMapper : Profile
{
    public GradingPeriodMapper()
    {
        CreateMap<GradingPeriodDto, GradingPeriod>();
        CreateMap<GradingPeriod, GetGradingPeriodDto>();
    }
}
