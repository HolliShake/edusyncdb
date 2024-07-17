
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleToProficiencyLevelService:GenericService<SkillsFrameworkJobRoleToProficiencyLevel>, ISkillsFrameworkJobRoleToProficiencyLevelService
{
    public SkillsFrameworkJobRoleToProficiencyLevelService(AppDbContext context):base(context)
    {
    }
}
