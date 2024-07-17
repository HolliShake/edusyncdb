using AutoMapper;
using APPLICATION.Dto.PortfolioProvider;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioProviderMapper : Profile
{
    public PortfolioProviderMapper()
    {
        CreateMap<PortfolioProviderDto, PortfolioProvider>();
        CreateMap<PortfolioProvider, GetPortfolioProviderDto>();
    }
}
