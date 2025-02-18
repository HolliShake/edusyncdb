using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkCourseToCompetencyService:GenericService<SkillsFrameworkCourseToCompetency, GetSkillsFrameworkCourseToCompetencyDto>, ISkillsFrameworkCourseToCompetencyService
{
    public SkillsFrameworkCourseToCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
