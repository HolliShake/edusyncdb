
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using DOMAIN.Model;

namespace APPLICATION.IService.AdmissionData;

public interface IAdmissionEvaluationScheduleService:IGenericService<AdmissionEvaluationSchedule, GetAdmissionEvaluationScheduleDto>
{
    public Task<ICollection<GetAdmissionEvaluationScheduleDto>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId);
}
