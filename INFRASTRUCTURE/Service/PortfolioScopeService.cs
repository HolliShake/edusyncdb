
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioScopeService:GenericService<PortfolioScope>, IPortfolioScopeService
{
    public PortfolioScopeService(AppDbContext context):base(context)
    {
    }
}
