
using APPLICATION.Dto.AdmissionScore;
using DOMAIN.Model;

namespace APPLICATION.IService.AdmissionData;

public interface IAdmissionScoreService:IGenericService<AdmissionScore, GetAdmissionScoreDto>
{
    public Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionEvaluationScheduleId(int admissionEvaluationScheduleId);
    public Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionProgramRequirementId(int admissionProgramRequirementId);
    public Task<ICollection<GetAdmissionScoreDto>> GetAdmissionScoreByAdmissionApplicantId(int admissionApplicantId);
}
