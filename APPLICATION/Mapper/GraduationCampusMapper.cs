using AutoMapper;
using APPLICATION.Dto.GraduationCampus;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GraduationCampusMapper : Profile
{
    public GraduationCampusMapper()
    {
        CreateMap<GraduationCampusDto, GraduationCampus>();
        CreateMap<GraduationCampus, GetGraduationCampusDto>();
    }
}
