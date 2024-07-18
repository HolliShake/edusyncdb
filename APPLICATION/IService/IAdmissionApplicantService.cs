using APPLICATION.Dto.AdmissionApplicant;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionApplicantService:IGenericService<AdmissionApplicant, GetAdmissionApplicantDto>
{
}
