
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionTypeService:GenericService<PortfolioSessionType>, IPortfolioSessionTypeService
{
    public PortfolioSessionTypeService(AppDbContext context):base(context)
    {
    }
}
