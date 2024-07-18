using APPLICATION.Dto.PortfolioType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioTypeService:GenericService<PortfolioType, GetPortfolioTypeDto>, IPortfolioTypeService
{
    public PortfolioTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
