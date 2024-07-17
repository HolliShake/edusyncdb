
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkSkillsToCompetencyService:GenericService<SkillsFrameworkSkillsToCompetency>, ISkillsFrameworkSkillsToCompetencyService
{
    public SkillsFrameworkSkillsToCompetencyService(AppDbContext context):base(context)
    {
    }
}
