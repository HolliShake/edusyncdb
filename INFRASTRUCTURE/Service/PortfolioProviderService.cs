
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioProviderService:GenericService<PortfolioProvider>, IPortfolioProviderService
{
    public PortfolioProviderService(AppDbContext context):base(context)
    {
    }
}
