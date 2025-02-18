using AutoMapper;
using APPLICATION.Dto.EnrollmentPayment;
using APPLICATION.IService.EnrollmentData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EnrollmentData;

public class EnrollmentPaymentService:GenericService<EnrollmentPayment, GetEnrollmentPaymentDto>, IEnrollmentPaymentService
{
    public EnrollmentPaymentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
