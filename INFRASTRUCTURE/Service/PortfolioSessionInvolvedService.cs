using APPLICATION.Dto.PortfolioSessionInvolved;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioSessionInvolvedService:GenericService<PortfolioSessionInvolved, GetPortfolioSessionInvolvedDto>, IPortfolioSessionInvolvedService
{
    public PortfolioSessionInvolvedService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
