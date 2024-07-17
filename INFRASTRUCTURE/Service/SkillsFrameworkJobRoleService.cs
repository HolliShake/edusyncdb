
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleService:GenericService<SkillsFrameworkJobRole>, ISkillsFrameworkJobRoleService
{
    public SkillsFrameworkJobRoleService(AppDbContext context):base(context)
    {
    }
}
