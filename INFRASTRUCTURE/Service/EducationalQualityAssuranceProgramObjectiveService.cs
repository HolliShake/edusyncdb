
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceProgramObjectiveService:GenericService<EducationalQualityAssuranceProgramObjective>, IEducationalQualityAssuranceProgramObjectiveService
{
    public EducationalQualityAssuranceProgramObjectiveService(AppDbContext context):base(context)
    {
    }
}
