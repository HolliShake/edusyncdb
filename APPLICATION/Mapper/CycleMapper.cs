using AutoMapper;
using APPLICATION.Dto.Cycle;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CycleMapper : Profile
{
    public CycleMapper()
    {
        CreateMap<CycleDto, Cycle>();
        CreateMap<Cycle, GetCycleDto>();
    }
}
