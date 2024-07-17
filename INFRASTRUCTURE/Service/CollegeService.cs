
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CollegeService:GenericService<College>, ICollegeService
{
    public CollegeService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<College>> GetCollegesByCampusId(int campusId)
    {
        return await _dbModel.Where(c => c.CampusId == campusId).ToListAsync();
    }
}
