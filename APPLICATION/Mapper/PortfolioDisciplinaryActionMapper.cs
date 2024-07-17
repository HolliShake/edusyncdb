using AutoMapper;
using APPLICATION.Dto.PortfolioDisciplinaryAction;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PortfolioDisciplinaryActionMapper : Profile
{
    public PortfolioDisciplinaryActionMapper()
    {
        CreateMap<PortfolioDisciplinaryActionDto, PortfolioDisciplinaryAction>();
        CreateMap<PortfolioDisciplinaryAction, GetPortfolioDisciplinaryActionDto>();
    }
}
