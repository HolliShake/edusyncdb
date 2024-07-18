using APPLICATION.Dto.PortfolioEntry;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioEntryService:GenericService<PortfolioEntry, GetPortfolioEntryDto>, IPortfolioEntryService
{
    public PortfolioEntryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
