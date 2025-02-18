using APPLICATION.Dto.AdmissionApplicant;
using DOMAIN.Model;

namespace APPLICATION.IService.AdmissionData;

public interface IAdmissionApplicantService:IGenericService<AdmissionApplicant, GetAdmissionApplicantDto>
{
    public Task<object?> ApplyApplication(AdmissionApplicantGroupedDto group);
}
