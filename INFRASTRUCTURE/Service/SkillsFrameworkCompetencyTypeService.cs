
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyTypeService:GenericService<SkillsFrameworkCompetencyType>, ISkillsFrameworkCompetencyTypeService
{
    public SkillsFrameworkCompetencyTypeService(AppDbContext context):base(context)
    {
    }
}
