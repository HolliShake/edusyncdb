using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkTrackSpecializationMapper : Profile
{
    public SkillsFrameworkTrackSpecializationMapper()
    {
        CreateMap<SkillsFrameworkTrackSpecializationDto, SkillsFrameworkTrackSpecialization>();
        CreateMap<SkillsFrameworkTrackSpecialization, GetSkillsFrameworkTrackSpecializationDto>();
    }
}
