using AutoMapper;
using APPLICATION.Dto.Schedule;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScheduleMapper : Profile
{
    public ScheduleMapper()
    {
        CreateMap<ScheduleDto, Schedule>();
        CreateMap<Schedule, GetScheduleDto>();
    }
}
