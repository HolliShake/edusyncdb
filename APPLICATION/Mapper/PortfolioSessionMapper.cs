using AutoMapper;
using APPLICATION.Dto.PortfolioSession;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioSessionMapper : Profile
{
    public PortfolioSessionMapper()
    {
        CreateMap<PortfolioSessionDto, PortfolioSession>();
        CreateMap<PortfolioSession, GetPortfolioSessionDto>();
    }
}
