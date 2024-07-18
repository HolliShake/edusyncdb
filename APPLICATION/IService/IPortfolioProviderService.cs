using APPLICATION.Dto.PortfolioProvider;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IPortfolioProviderService:IGenericService<PortfolioProvider, GetPortfolioProviderDto>
{
}
