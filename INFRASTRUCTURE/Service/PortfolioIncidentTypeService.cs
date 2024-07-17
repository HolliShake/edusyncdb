
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioIncidentTypeService:GenericService<PortfolioIncidentType>, IPortfolioIncidentTypeService
{
    public PortfolioIncidentTypeService(AppDbContext context):base(context)
    {
    }
}
