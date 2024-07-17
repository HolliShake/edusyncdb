using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkGroupLevel;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkGroupLevelMapper : Profile
{
    public SkillsFrameworkGroupLevelMapper()
    {
        CreateMap<SkillsFrameworkGroupLevelDto, SkillsFrameworkGroupLevel>();
        CreateMap<SkillsFrameworkGroupLevel, GetSkillsFrameworkGroupLevelDto>();
    }
}
