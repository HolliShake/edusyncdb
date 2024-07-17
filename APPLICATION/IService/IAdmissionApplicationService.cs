
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionApplicationService:IGenericService<AdmissionApplication>
{
    public Task<ICollection<AdmissionApplication>> GetAdmissionApplicationsByAdmissionScheduleId(int admissionScheduleId);
}
