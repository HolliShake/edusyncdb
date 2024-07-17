using AutoMapper;
using APPLICATION.Dto.SectorDiscipline;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SectorDisciplineMapper : Profile
{
    public SectorDisciplineMapper()
    {
        CreateMap<SectorDisciplineDto, SectorDiscipline>();
        CreateMap<SectorDiscipline, GetSectorDisciplineDto>();
    }
}
