using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkProficiencyLevelMapper : Profile
{
    public SkillsFrameworkProficiencyLevelMapper()
    {
        CreateMap<SkillsFrameworkProficiencyLevelDto, SkillsFrameworkProficiencyLevel>();
        CreateMap<SkillsFrameworkProficiencyLevel, GetSkillsFrameworkProficiencyLevelDto>();
    }
}
