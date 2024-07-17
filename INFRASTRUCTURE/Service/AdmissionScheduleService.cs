
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionScheduleService:GenericService<AdmissionSchedule>, IAdmissionScheduleService
{
    public AdmissionScheduleService(AppDbContext context):base(context)
    {
    }

    public new async Task<ICollection<AdmissionSchedule>> GetAllAsync()
    {
        return await _dbModel.Include(ads => ads.Cycle).ToListAsync();
    }

    public new async Task<ICollection<AdmissionSchedule>> GetByChunk(int max)
    {
        return await _dbModel.Include(ads => ads.Cycle).Take(max).ToListAsync();
    }

    public new async Task<AdmissionSchedule?> GetAsync(int id)
    {
        return await _dbModel.Include(ads => ads.Cycle).Where(ads => ads.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AdmissionSchedule>> GetAdmissionSchedulesByAcademicProgramId(int academicProgramId)
    {
        return await _dbModel
            .Include(ads => ads.AcademicProgram)
            .Include(ads => ads.Cycle)
            .Where(ads => ads.AcademicProgramId == academicProgramId)
            .ToListAsync();
    }

    public async Task<ICollection<AdmissionSchedule>> GetAdmissionSchedulesByCycleId(int cycleId)
    {
        return await _dbModel.Include(ads => ads.Cycle).Where(ads => ads.CycleId == cycleId).ToListAsync();
    }
}
