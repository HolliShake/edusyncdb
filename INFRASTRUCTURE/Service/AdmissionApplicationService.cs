
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionApplicationService:GenericService<AdmissionApplication>, IAdmissionApplicationService
{
    public AdmissionApplicationService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<AdmissionApplication>> GetAdmissionApplicationsByAdmissionScheduleId(int admissionScheduleId)
    {
        return await _dbModel.Where(aa => aa.AdmissionScheduleId == admissionScheduleId).ToListAsync();
    }
}
