
using APPLICATION.Dto.PortfolioSessionType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionTypeService:GenericService<PortfolioSessionType, GetPortfolioSessionTypeDto>, IPortfolioSessionTypeService
{
    public PortfolioSessionTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
