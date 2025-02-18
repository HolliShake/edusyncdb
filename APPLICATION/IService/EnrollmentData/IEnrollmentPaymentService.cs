using APPLICATION.Dto.EnrollmentPayment;
using DOMAIN.Model;

namespace APPLICATION.IService.EnrollmentData;

public interface IEnrollmentPaymentService:IGenericService<EnrollmentPayment, GetEnrollmentPaymentDto>
{
}
