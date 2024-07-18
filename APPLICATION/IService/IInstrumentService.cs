using APPLICATION.Dto.Instrument;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IInstrumentService:IGenericService<Instrument, GetInstrumentDto>
{
}
