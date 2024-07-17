
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradingPeriodService:GenericService<GradingPeriod>, IGradingPeriodService
{
    public GradingPeriodService(AppDbContext context):base(context)
    {
    }
}
