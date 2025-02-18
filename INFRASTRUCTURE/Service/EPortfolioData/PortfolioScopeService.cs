using AutoMapper;
using APPLICATION.Dto.PortfolioScope;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioScopeService:GenericService<PortfolioScope, GetPortfolioScopeDto>, IPortfolioScopeService
{
    public PortfolioScopeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
