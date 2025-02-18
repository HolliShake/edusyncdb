using AutoMapper;
using APPLICATION.Dto.PortfolioDisciplinaryAction;
using APPLICATION.IService.EPortfolioData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EPortfolioData;

public class PortfolioDisciplinaryActionService:GenericService<PortfolioDisciplinaryAction, GetPortfolioDisciplinaryActionDto>, IPortfolioDisciplinaryActionService
{
    public PortfolioDisciplinaryActionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
