
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BulletinService:GenericService<Bulletin>, IBulletinService
{
    public BulletinService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Bulletin>> GetBulletinsByBulletinCategoryId(int bulletinCategoryId)
    {
        return await _dbModel.Where(b => b.BulletinCategoryId == bulletinCategoryId).ToListAsync();
    }
}
