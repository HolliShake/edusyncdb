
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceProgramObjectiveToJobRoleService:GenericService<EducationalQualityAssuranceProgramObjectiveToJobRole>, IEducationalQualityAssuranceProgramObjectiveToJobRoleService
{
    public EducationalQualityAssuranceProgramObjectiveToJobRoleService(AppDbContext context):base(context)
    {
    }
}
