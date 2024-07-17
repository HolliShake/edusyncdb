
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentRoleService:GenericService<EnrollmentRole>, IEnrollmentRoleService
{
    public EnrollmentRoleService(AppDbContext context):base(context)
    {
    }
}
