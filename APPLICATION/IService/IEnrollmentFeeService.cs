
using APPLICATION.Dto.EnrollmentFee;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentFeeService:IGenericService<EnrollmentFee, GetEnrollmentFeeDto>
{
    public Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByObjectId(int objectId);
    public Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByFundSourceId(int fundSourceId);
}
