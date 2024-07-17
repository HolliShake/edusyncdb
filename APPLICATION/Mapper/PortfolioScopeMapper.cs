using AutoMapper;
using APPLICATION.Dto.PortfolioScope;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioScopeMapper : Profile
{
    public PortfolioScopeMapper()
    {
        CreateMap<PortfolioScopeDto, PortfolioScope>();
        CreateMap<PortfolioScope, GetPortfolioScopeDto>();
    }
}
