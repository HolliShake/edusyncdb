
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkSkillsService:GenericService<SkillsFrameworkSkills>, ISkillsFrameworkSkillsService
{
    public SkillsFrameworkSkillsService(AppDbContext context):base(context)
    {
    }
}
