using APPLICATION.Dto.PortfolioDisciplinaryAction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioDisciplinaryActionService:GenericService<PortfolioDisciplinaryAction, GetPortfolioDisciplinaryActionDto>, IPortfolioDisciplinaryActionService
{
    public PortfolioDisciplinaryActionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
