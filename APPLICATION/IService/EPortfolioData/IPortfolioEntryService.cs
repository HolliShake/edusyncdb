using APPLICATION.Dto.PortfolioEntry;
using DOMAIN.Model;

namespace APPLICATION.IService.EPortfolioData;

public interface IPortfolioEntryService:IGenericService<PortfolioEntry, GetPortfolioEntryDto>
{
}
