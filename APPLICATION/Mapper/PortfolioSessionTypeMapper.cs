using AutoMapper;
using APPLICATION.Dto.PortfolioSessionType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioSessionTypeMapper : Profile
{
    public PortfolioSessionTypeMapper()
    {
        CreateMap<PortfolioSessionTypeDto, PortfolioSessionType>();
        CreateMap<PortfolioSessionType, GetPortfolioSessionTypeDto>();
    }
}
