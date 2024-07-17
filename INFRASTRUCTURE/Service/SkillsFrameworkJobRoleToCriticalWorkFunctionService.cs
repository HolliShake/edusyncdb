
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleToCriticalWorkFunctionService:GenericService<SkillsFrameworkJobRoleToCriticalWorkFunction>, ISkillsFrameworkJobRoleToCriticalWorkFunctionService
{
    public SkillsFrameworkJobRoleToCriticalWorkFunctionService(AppDbContext context):base(context)
    {
    }
}
