
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkTrackSpecializationService:GenericService<SkillsFrameworkTrackSpecialization>, ISkillsFrameworkTrackSpecializationService
{
    public SkillsFrameworkTrackSpecializationService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<SkillsFrameworkTrackSpecialization>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId)
    {
        return await _dbModel
            .Include(sfts => sfts.SectorDiscipline)
            .Where(sfts => sfts.SectorDisciplineId == sectorDisciplineId)
            .ToListAsync();
    }
}
