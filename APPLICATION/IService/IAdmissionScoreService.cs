
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionScoreService:IGenericService<AdmissionScore>
{
    public Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId);
    public Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId);
    public Task<ICollection<AdmissionScore>> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId);
}
