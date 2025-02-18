using AutoMapper;
using APPLICATION.Dto.PortfolioIncident;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioIncidentService:GenericService<PortfolioIncident, GetPortfolioIncidentDto>, IPortfolioIncidentService
{
    public PortfolioIncidentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
