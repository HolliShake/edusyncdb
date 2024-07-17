
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SectorDisciplineService:GenericService<SectorDiscipline>, ISectorDisciplineService
{
    public SectorDisciplineService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<SectorDiscipline>> GetAllParentSectorDiscipline()
    {
        return await _dbModel
           .Where(sd => sd.ParentId == null)
           .ToListAsync();
    }
    public async Task<ICollection<SectorDiscipline>> GetSectorDisciplineByParentSectorDisciplineId(int parentId)
    {
        return await _dbModel
            .Where(sd => sd.ParentId != null)
            .Where(sd => sd.ParentId == parentId)
            .ToListAsync();
    }
}
