
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyService:GenericService<SkillsFrameworkCompetency>, ISkillsFrameworkCompetencyService
{
    public SkillsFrameworkCompetencyService(AppDbContext context):base(context)
    {
    }
}
