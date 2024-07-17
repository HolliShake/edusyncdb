
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionService:GenericService<PortfolioSession>, IPortfolioSessionService
{
    public PortfolioSessionService(AppDbContext context):base(context)
    {
    }
}
