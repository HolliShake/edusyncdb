using APPLICATION.Dto.GradingPeriod;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IGradingPeriodService:IGenericService<GradingPeriod, GetGradingPeriodDto>
{
    public Task<ICollection<GetGradingPeriodDto>> GetGradingPeriodByCollegeId(int collegeId);
}
