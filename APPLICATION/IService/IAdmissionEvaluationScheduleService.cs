
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionEvaluationScheduleService:IGenericService<AdmissionEvaluationSchedule, GetAdmissionEvaluationScheduleDto>
{
    public Task<ICollection<GetAdmissionEvaluationScheduleDto>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId);
}
