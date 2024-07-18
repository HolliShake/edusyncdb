using APPLICATION.Dto.PortfolioIncident;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioIncidentService:GenericService<PortfolioIncident, GetPortfolioIncidentDto>, IPortfolioIncidentService
{
    public PortfolioIncidentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
