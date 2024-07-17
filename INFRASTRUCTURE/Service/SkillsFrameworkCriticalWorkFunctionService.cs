
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCriticalWorkFunctionService:GenericService<SkillsFrameworkCriticalWorkFunction>, ISkillsFrameworkCriticalWorkFunctionService
{
    public SkillsFrameworkCriticalWorkFunctionService(AppDbContext context):base(context)
    {
    }
}
