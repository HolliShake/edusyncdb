using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceEducationalGoalService:GenericService<EducationalQualityAssuranceEducationalGoal, GetEducationalQualityAssuranceEducationalGoalDto>, IEducationalQualityAssuranceEducationalGoalService
{
    public EducationalQualityAssuranceEducationalGoalService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
