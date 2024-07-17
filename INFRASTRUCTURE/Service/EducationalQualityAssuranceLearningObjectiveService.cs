
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceLearningObjectiveService:GenericService<EducationalQualityAssuranceLearningObjective>, IEducationalQualityAssuranceLearningObjectiveService
{
    public EducationalQualityAssuranceLearningObjectiveService(AppDbContext context):base(context)
    {
    }
}
