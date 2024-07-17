
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioTypeService:GenericService<PortfolioType>, IPortfolioTypeService
{
    public PortfolioTypeService(AppDbContext context):base(context)
    {
    }
}
