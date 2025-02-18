using AutoMapper;
using APPLICATION.Dto.PortfolioType;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioTypeService:GenericService<PortfolioType, GetPortfolioTypeDto>, IPortfolioTypeService
{
    public PortfolioTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
