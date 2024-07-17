using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkSkillsToCompetencyMapper : Profile
{
    public SkillsFrameworkSkillsToCompetencyMapper()
    {
        CreateMap<SkillsFrameworkSkillsToCompetencyDto, SkillsFrameworkSkillsToCompetency>();
        CreateMap<SkillsFrameworkSkillsToCompetency, GetSkillsFrameworkSkillsToCompetencyDto>();
    }
}
