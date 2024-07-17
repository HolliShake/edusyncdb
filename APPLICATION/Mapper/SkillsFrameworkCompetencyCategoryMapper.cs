using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkCompetencyCategoryMapper : Profile
{
    public SkillsFrameworkCompetencyCategoryMapper()
    {
        CreateMap<SkillsFrameworkCompetencyCategoryDto, SkillsFrameworkCompetencyCategory>();
        CreateMap<SkillsFrameworkCompetencyCategory, GetSkillsFrameworkCompetencyCategoryDto>();
    }
}
