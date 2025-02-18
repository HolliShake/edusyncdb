using AutoMapper;
using APPLICATION.Dto.PortfolioEntry;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioEntryService:GenericService<PortfolioEntry, GetPortfolioEntryDto>, IPortfolioEntryService
{
    public PortfolioEntryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
