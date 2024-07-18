using APPLICATION.Dto.EnrollmentBilling;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentBillingService:IGenericService<EnrollmentBilling, GetEnrollmentBillingDto>
{
    public Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByEnrollmentId(int enrollmentId);
    public Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByEnrollmentFeeId(int enrollmenFeetId);
    public Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByCycleId(int cycleId);
    public Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByVoucherId(int voucherId);
}
