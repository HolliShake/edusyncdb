
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CampusService:GenericService<Campus>, ICampusService
{
    public CampusService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Campus>> GetCampusByAgendyId(int agencyId)
    {
        return await _dbModel.Where(c => c.AgencyId == agencyId).ToListAsync();
    }
}
