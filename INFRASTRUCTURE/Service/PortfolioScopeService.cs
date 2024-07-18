using APPLICATION.Dto.PortfolioScope;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioScopeService:GenericService<PortfolioScope, GetPortfolioScopeDto>, IPortfolioScopeService
{
    public PortfolioScopeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
