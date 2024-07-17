
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentLogService:GenericService<EnrollmentLog>, IEnrollmentLogService
{
    public EnrollmentLogService(AppDbContext context):base(context)
    {
    }
}
