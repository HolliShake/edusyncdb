using APPLICATION.Dto.GradingPeriod;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradingPeriodService:GenericService<GradingPeriod, GetGradingPeriodDto>, IGradingPeriodService
{
    public GradingPeriodService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
