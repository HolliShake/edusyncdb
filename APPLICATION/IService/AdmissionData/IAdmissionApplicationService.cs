using APPLICATION.Dto.AdmissionApplication;
using DOMAIN.Model;

namespace APPLICATION.IService.AdmissionData;

public interface IAdmissionApplicationService:IGenericService<AdmissionApplication, GetAdmissionApplicationDto>
{
    public Task<ICollection<GetAdmissionApplicationDto>> GetAdmissionApplicationsByAdmissionScheduleId(int admissionScheduleId);
}
