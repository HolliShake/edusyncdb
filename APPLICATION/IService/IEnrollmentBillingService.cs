
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentBillingService:IGenericService<EnrollmentBilling>
{
    public Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByEnrollmentId(int enrollmentId);
    public Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByEnrollmentFeeId(int enrollmenFeetId);
    public Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByCycleId(int cycleId);
    public Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByVoucherId(int voucherId);
}
