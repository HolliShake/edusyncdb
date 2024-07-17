using AutoMapper;
using APPLICATION.Dto.PortfolioSessionInvolved;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioSessionInvolvedMapper : Profile
{
    public PortfolioSessionInvolvedMapper()
    {
        CreateMap<PortfolioSessionInvolvedDto, PortfolioSessionInvolved>();
        CreateMap<PortfolioSessionInvolved, GetPortfolioSessionInvolvedDto>();
    }
}
