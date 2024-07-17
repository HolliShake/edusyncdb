using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkCourseToCompetencyMapper : Profile
{
    public SkillsFrameworkCourseToCompetencyMapper()
    {
        CreateMap<SkillsFrameworkCourseToCompetencyDto, SkillsFrameworkCourseToCompetency>();
        CreateMap<SkillsFrameworkCourseToCompetency, GetSkillsFrameworkCourseToCompetencyDto>();
    }
}
