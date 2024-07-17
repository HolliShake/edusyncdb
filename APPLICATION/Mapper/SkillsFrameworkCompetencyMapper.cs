using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCompetency;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkCompetencyMapper : Profile
{
    public SkillsFrameworkCompetencyMapper()
    {
        CreateMap<SkillsFrameworkCompetencyDto, SkillsFrameworkCompetency>();
        CreateMap<SkillsFrameworkCompetency, GetSkillsFrameworkCompetencyDto>();
    }
}
