using AutoMapper;
using APPLICATION.Dto.PortfolioIncidentType;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioIncidentTypeService:GenericService<PortfolioIncidentType, GetPortfolioIncidentTypeDto>, IPortfolioIncidentTypeService
{
    public PortfolioIncidentTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
