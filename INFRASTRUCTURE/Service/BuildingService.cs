
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BuildingService:GenericService<Building>, IBuildingService
{
    public BuildingService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Building>> GetBuildingByCampusId(int campusId)
    {
        return await _dbModel.Where(b => b.CampusId == campusId).ToListAsync();
    }
}
