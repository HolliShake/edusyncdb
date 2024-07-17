
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionInvolvedService:GenericService<PortfolioSessionInvolved>, IPortfolioSessionInvolvedService
{
    public PortfolioSessionInvolvedService(AppDbContext context):base(context)
    {
    }
}
