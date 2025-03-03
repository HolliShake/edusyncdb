using AutoMapper;
using APPLICATION.Dto.GraduateAttributes;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GraduateAttributesMapper : Profile
{
    public GraduateAttributesMapper()
    {
        CreateMap<GraduateAttributesDto, GraduateAttributes>();
        CreateMap<GraduateAttributes, GetGraduateAttributesDto>();
    }
}
