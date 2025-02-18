using APPLICATION.Dto.Instrument;
using DOMAIN.Model;

namespace APPLICATION.IService.SurveyFormData;

public interface IInstrumentService:IGenericService<Instrument, GetInstrumentDto>
{
    public Task<object?> GetInstrumentInfo(int id);
    public Task<object?> CreateInstrumentByGroup(InstrumentGroupDto group);
}
