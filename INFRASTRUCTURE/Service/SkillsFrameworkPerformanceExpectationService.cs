
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkPerformanceExpectationService:GenericService<SkillsFrameworkPerformanceExpectation>, ISkillsFrameworkPerformanceExpectationService
{
    public SkillsFrameworkPerformanceExpectationService(AppDbContext context):base(context)
    {
    }
}
