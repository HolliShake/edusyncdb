using AutoMapper;
using APPLICATION.Dto.OtherSchool;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class OtherSchoolMapper : Profile
{
    public OtherSchoolMapper()
    {
        CreateMap<OtherSchoolDto, OtherSchool>();
        CreateMap<OtherSchool, GetOtherSchoolDto>();
    }
}
