
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceAssessmentTypeService:GenericService<EducationalQualityAssuranceAssessmentType>, IEducationalQualityAssuranceAssessmentTypeService
{
    public EducationalQualityAssuranceAssessmentTypeService(AppDbContext context):base(context)
    {
    }
}
