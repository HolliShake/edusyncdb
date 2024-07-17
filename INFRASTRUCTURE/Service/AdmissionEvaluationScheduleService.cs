
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionEvaluationScheduleService:GenericService<AdmissionEvaluationSchedule>, IAdmissionEvaluationScheduleService
{
    public AdmissionEvaluationScheduleService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<AdmissionEvaluationSchedule>> GetAdmissionEvaluationSchedulesByAdmissionScheduleId(int admissionSchedueId)
    {
        return await _dbModel.Where(aes => aes.AdmissionScheduleId == admissionSchedueId).ToListAsync();
    }
}
