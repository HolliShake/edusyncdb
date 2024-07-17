using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkJobRoleToProficiencyLevelMapper : Profile
{
    public SkillsFrameworkJobRoleToProficiencyLevelMapper()
    {
        CreateMap<SkillsFrameworkJobRoleToProficiencyLevelDto, SkillsFrameworkJobRoleToProficiencyLevel>();
        CreateMap<SkillsFrameworkJobRoleToProficiencyLevel, GetSkillsFrameworkJobRoleToProficiencyLevelDto>();
    }
}
