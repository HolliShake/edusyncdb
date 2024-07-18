using APPLICATION.Dto.EnrollmentPayment;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentPaymentService:GenericService<EnrollmentPayment, GetEnrollmentPaymentDto>, IEnrollmentPaymentService
{
    public EnrollmentPaymentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
