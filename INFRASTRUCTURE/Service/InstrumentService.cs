using APPLICATION.Dto.Instrument;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class InstrumentService:GenericService<Instrument, GetInstrumentDto>, IInstrumentService
{
    public InstrumentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
