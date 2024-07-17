
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceEducationalGoalService:GenericService<EducationalQualityAssuranceEducationalGoal>, IEducationalQualityAssuranceEducationalGoalService
{
    public EducationalQualityAssuranceEducationalGoalService(AppDbContext context):base(context)
    {
    }
}
