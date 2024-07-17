
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkGroupLevelService:GenericService<SkillsFrameworkGroupLevel>, ISkillsFrameworkGroupLevelService
{
    public SkillsFrameworkGroupLevelService(AppDbContext context):base(context)
    {
    }
}
