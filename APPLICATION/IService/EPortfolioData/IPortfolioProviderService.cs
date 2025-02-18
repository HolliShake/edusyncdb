using APPLICATION.Dto.PortfolioProvider;
using DOMAIN.Model;

namespace APPLICATION.IService.EPortfolioData;

public interface IPortfolioProviderService:IGenericService<PortfolioProvider, GetPortfolioProviderDto>
{
}
