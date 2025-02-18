using AutoMapper;
using APPLICATION.Dto.PortfolioSessionInvolved;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioSessionInvolvedService:GenericService<PortfolioSessionInvolved, GetPortfolioSessionInvolvedDto>, IPortfolioSessionInvolvedService
{
    public PortfolioSessionInvolvedService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
