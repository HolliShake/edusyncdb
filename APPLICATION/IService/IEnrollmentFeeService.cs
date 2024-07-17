
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentFeeService:IGenericService<EnrollmentFee>
{
    public Task<ICollection<EnrollmentFee>> GetEnrollmentFeesByObjectId(int objectId);
    public Task<ICollection<EnrollmentFee>> GetEnrollmentFeesByFundSourceId(int fundSourceId);
}
