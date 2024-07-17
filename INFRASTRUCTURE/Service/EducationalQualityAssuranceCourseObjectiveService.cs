
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceCourseObjectiveService:GenericService<EducationalQualityAssuranceCourseObjective>, IEducationalQualityAssuranceCourseObjectiveService
{
    public EducationalQualityAssuranceCourseObjectiveService(AppDbContext context):base(context)
    {
    }
}
