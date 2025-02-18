using AutoMapper;
using APPLICATION.Dto.PortfolioSession;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioSessionService:GenericService<PortfolioSession, GetPortfolioSessionDto>, IPortfolioSessionService
{
    public PortfolioSessionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
