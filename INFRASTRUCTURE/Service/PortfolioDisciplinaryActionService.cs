
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PortfolioDisciplinaryActionService:GenericService<PortfolioDisciplinaryAction>, IPortfolioDisciplinaryActionService
{
    public PortfolioDisciplinaryActionService(AppDbContext context):base(context)
    {
    }
}
