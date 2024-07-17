using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkSkills;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkSkillsMapper : Profile
{
    public SkillsFrameworkSkillsMapper()
    {
        CreateMap<SkillsFrameworkSkillsDto, SkillsFrameworkSkills>();
        CreateMap<SkillsFrameworkSkills, GetSkillsFrameworkSkillsDto>();
    }
}
