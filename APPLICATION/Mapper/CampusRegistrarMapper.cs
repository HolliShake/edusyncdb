using AutoMapper;
using APPLICATION.Dto.CampusRegistrar;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CampusRegistrarMapper : Profile
{
    public CampusRegistrarMapper()
    {
        CreateMap<CampusRegistrarDto, CampusRegistrar>();
        CreateMap<CampusRegistrar, GetCampusRegistrarDto>();
    }
}
