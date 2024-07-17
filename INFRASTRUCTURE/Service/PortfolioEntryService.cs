
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioEntryService:GenericService<PortfolioEntry>, IPortfolioEntryService
{
    public PortfolioEntryService(AppDbContext context):base(context)
    {
    }
}
