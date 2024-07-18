using APPLICATION.Dto.AdmissionSchedule;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionScheduleService:IGenericService<AdmissionSchedule, GetAdmissionScheduleDto>
{
    public Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByCycleId(int cycleId);
}
