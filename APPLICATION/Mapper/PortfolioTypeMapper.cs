using AutoMapper;
using APPLICATION.Dto.PortfolioType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioTypeMapper : Profile
{
    public PortfolioTypeMapper()
    {
        CreateMap<PortfolioTypeDto, PortfolioType>();
        CreateMap<PortfolioType, GetPortfolioTypeDto>();
    }
}
