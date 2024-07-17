using AutoMapper;
using APPLICATION.Dto.PortfolioIncidentType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioIncidentTypeMapper : Profile
{
    public PortfolioIncidentTypeMapper()
    {
        CreateMap<PortfolioIncidentTypeDto, PortfolioIncidentType>();
        CreateMap<PortfolioIncidentType, GetPortfolioIncidentTypeDto>();
    }
}
