
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioIncidentService:GenericService<PortfolioIncident>, IPortfolioIncidentService
{
    public PortfolioIncidentService(AppDbContext context):base(context)
    {
    }
}
