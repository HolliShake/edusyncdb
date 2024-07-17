using AutoMapper;
using APPLICATION.Dto.Agency;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AgencyMapper : Profile
{
    public AgencyMapper()
    {
        CreateMap<AgencyDto, Agency>();
        CreateMap<Agency, GetAgencyDto>();
    }
}
