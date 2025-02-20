using APPLICATION.Dto.AdmissionSchedule;
using DOMAIN.Model;

namespace APPLICATION.IService.AdmissionData;

public interface IAdmissionScheduleService:IGenericService<AdmissionSchedule, GetAdmissionScheduleDto>
{
    public Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetAdmissionScheduleDto>> GetAdmissionSchedulesByCycleId(int cycleId);
    public Task<object> GetOpenAdmissionScheduleGroupedByCampus(int schoolId);
    public Task<object> GetOpenAdmissionScheduleGroupedByCampusViaCampusName(string campusShortName);
}
