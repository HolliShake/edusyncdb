using APPLICATION.Dto.PortfolioEntry;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IPortfolioEntryService:IGenericService<PortfolioEntry, GetPortfolioEntryDto>
{
}
