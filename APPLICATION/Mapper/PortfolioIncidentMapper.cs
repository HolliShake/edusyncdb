using AutoMapper;
using APPLICATION.Dto.PortfolioIncident;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioIncidentMapper : Profile
{
    public PortfolioIncidentMapper()
    {
        CreateMap<PortfolioIncidentDto, PortfolioIncident>();
        CreateMap<PortfolioIncident, GetPortfolioIncidentDto>();
    }
}
