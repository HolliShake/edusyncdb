using AutoMapper;
using APPLICATION.Dto.PortfolioEntry;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioEntryMapper : Profile
{
    public PortfolioEntryMapper()
    {
        CreateMap<PortfolioEntryDto, PortfolioEntry>();
        CreateMap<PortfolioEntry, GetPortfolioEntryDto>();
    }
}
