
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkPerformaceExpectationToJobRoleService:GenericService<SkillsFrameworkPerformaceExpectationToJobRole>, ISkillsFrameworkPerformaceExpectationToJobRoleService
{
    public SkillsFrameworkPerformaceExpectationToJobRoleService(AppDbContext context):base(context)
    {
    }
}
