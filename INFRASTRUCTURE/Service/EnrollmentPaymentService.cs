
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentPaymentService:GenericService<EnrollmentPayment>, IEnrollmentPaymentService
{
    public EnrollmentPaymentService(AppDbContext context):base(context)
    {
    }
}
