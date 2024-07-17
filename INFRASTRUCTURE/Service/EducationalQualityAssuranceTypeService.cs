
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceTypeService:GenericService<EducationalQualityAssuranceType>, IEducationalQualityAssuranceTypeService
{
    public EducationalQualityAssuranceTypeService(AppDbContext context):base(context)
    {
    }
}
