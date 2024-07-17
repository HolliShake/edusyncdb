using AutoMapper;
using APPLICATION.Dto.Instrument;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class InstrumentMapper : Profile
{
    public InstrumentMapper()
    {
        CreateMap<InstrumentDto, Instrument>();
        CreateMap<Instrument, GetInstrumentDto>();
    }
}
