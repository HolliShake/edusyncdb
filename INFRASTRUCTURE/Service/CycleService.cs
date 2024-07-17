
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CycleService:GenericService<Cycle>, ICycleService
{
    public CycleService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Cycle>> GetCycleByCampusId(int campusId)
    {
        return await _dbModel.Where(c => c.CampusId == campusId).ToListAsync();
    }
}
