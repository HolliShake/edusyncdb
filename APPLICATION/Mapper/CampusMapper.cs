using AutoMapper;
using APPLICATION.Dto.Campus;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CampusMapper : Profile
{
    public CampusMapper()
    {
        CreateMap<CampusDto, Campus>();
        CreateMap<Campus, GetCampusDto>();
    }
}
