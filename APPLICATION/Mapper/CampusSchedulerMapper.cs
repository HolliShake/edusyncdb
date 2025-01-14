using AutoMapper;
using APPLICATION.Dto.CampusScheduler;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CampusSchedulerMapper : Profile
{
    public CampusSchedulerMapper()
    {
        CreateMap<CampusSchedulerDto, CampusScheduler>();
        CreateMap<CampusScheduler, GetCampusSchedulerDto>();
    }
}
