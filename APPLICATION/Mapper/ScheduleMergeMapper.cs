using AutoMapper;
using APPLICATION.Dto.ScheduleMerge;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScheduleMergeMapper : Profile
{
    public ScheduleMergeMapper()
    {
        CreateMap<ScheduleMergeDto, ScheduleMerge>();
        CreateMap<ScheduleMerge, GetScheduleMergeDto>();
    }
}
