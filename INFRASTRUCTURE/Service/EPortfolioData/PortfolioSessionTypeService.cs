using AutoMapper;
using APPLICATION.Dto.PortfolioSessionType;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioSessionTypeService:GenericService<PortfolioSessionType, GetPortfolioSessionTypeDto>, IPortfolioSessionTypeService
{
    public PortfolioSessionTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
