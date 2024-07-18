using APPLICATION.Dto.PortfolioProvider;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioProviderService:GenericService<PortfolioProvider, GetPortfolioProviderDto>, IPortfolioProviderService
{
    public PortfolioProviderService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
