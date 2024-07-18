using APPLICATION.Dto.PortfolioSession;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionService:GenericService<PortfolioSession, GetPortfolioSessionDto>, IPortfolioSessionService
{
    public PortfolioSessionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
