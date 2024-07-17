
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionEvaluationScheduleService:IGenericService<AdmissionEvaluationSchedule>
{
    public Task<ICollection<AdmissionEvaluationSchedule>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId);
}
