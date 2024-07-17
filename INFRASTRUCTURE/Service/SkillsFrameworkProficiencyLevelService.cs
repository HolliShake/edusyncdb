
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkProficiencyLevelService:GenericService<SkillsFrameworkProficiencyLevel>, ISkillsFrameworkProficiencyLevelService
{
    public SkillsFrameworkProficiencyLevelService(AppDbContext context):base(context)
    {
    }
}
