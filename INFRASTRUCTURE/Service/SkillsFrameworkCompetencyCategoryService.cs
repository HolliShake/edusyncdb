
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyCategoryService:GenericService<SkillsFrameworkCompetencyCategory>, ISkillsFrameworkCompetencyCategoryService
{
    public SkillsFrameworkCompetencyCategoryService(AppDbContext context):base(context)
    {
    }
}
