using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionScheduleService:IGenericService<AdmissionSchedule>
{
    public Task<ICollection<AdmissionSchedule>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<AdmissionSchedule>> GetAdmissionSchedulesByCycleId(int cycleId);
}
