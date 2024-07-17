
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class InstrumentService:GenericService<Instrument>, IInstrumentService
{
    public InstrumentService(AppDbContext context):base(context)
    {
    }
}
