using APPLICATION.Dto.SkillsFrameworkCourseToCompetency;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCourseToCompetencyService:GenericService<SkillsFrameworkCourseToCompetency, GetSkillsFrameworkCourseToCompetencyDto>, ISkillsFrameworkCourseToCompetencyService
{
    public SkillsFrameworkCourseToCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
