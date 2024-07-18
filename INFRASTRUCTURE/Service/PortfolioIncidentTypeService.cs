using APPLICATION.Dto.PortfolioIncidentType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioIncidentTypeService:GenericService<PortfolioIncidentType, GetPortfolioIncidentTypeDto>, IPortfolioIncidentTypeService
{
    public PortfolioIncidentTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
