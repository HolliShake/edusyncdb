using APPLICATION.Dto.EnrollmentPayment;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentPaymentService:IGenericService<EnrollmentPayment, GetEnrollmentPaymentDto>
{
}
