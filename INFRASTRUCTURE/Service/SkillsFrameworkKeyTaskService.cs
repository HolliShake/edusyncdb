
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkKeyTaskService:GenericService<SkillsFrameworkKeyTask>, ISkillsFrameworkKeyTaskService
{
    public SkillsFrameworkKeyTaskService(AppDbContext context):base(context)
    {
    }
}
