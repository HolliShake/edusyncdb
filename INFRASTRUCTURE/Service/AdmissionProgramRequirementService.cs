
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AdmissionProgramRequirementService:GenericService<AdmissionProgramRequirement>, IAdmissionProgramRequirementService
{
    public AdmissionProgramRequirementService(AppDbContext context):base(context)
    {
    }

    public new async Task<ICollection<AdmissionProgramRequirement>> GetAllAsync()
    {
        return await _dbModel.Include(apr => apr.Requirement).ToListAsync();
    }

    public new async Task<ICollection<AdmissionProgramRequirement>> GetByChunk(int max)
    {
        return await _dbModel.Include(apr => apr.Requirement).Take(max).ToListAsync();
    }

    public new async Task<AdmissionProgramRequirement?> GetAsync(int id)
    {
        return await _dbModel.Include(apr => apr.Requirement).Where(apr => apr.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AdmissionProgramRequirement>> GetEnabledAdmissionProgramRequirements()
    {
        return await _dbModel.Include(apr => apr.Requirement).Where(apr => apr.IsEnabled).ToListAsync();
    }
}
