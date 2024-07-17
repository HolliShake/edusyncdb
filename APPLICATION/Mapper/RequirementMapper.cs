using AutoMapper;
using APPLICATION.Dto.Requirement;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class RequirementMapper : Profile
{
    public RequirementMapper()
    {
        CreateMap<RequirementDto, Requirement>();
        CreateMap<Requirement, GetRequirementDto>();
    }
}
