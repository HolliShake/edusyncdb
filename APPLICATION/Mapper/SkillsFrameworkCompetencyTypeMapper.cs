using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCompetencyType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkCompetencyTypeMapper : Profile
{
    public SkillsFrameworkCompetencyTypeMapper()
    {
        CreateMap<SkillsFrameworkCompetencyTypeDto, SkillsFrameworkCompetencyType>();
        CreateMap<SkillsFrameworkCompetencyType, GetSkillsFrameworkCompetencyTypeDto>();
    }
}
