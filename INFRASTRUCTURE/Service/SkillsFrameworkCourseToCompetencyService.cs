
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCourseToCompetencyService:GenericService<SkillsFrameworkCourseToCompetency>, ISkillsFrameworkCourseToCompetencyService
{
    public SkillsFrameworkCourseToCompetencyService(AppDbContext context):base(context)
    {
    }
}
