
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BulletinScopeService:GenericService<BulletinScope>, IBulletinScopeService
{
    public BulletinScopeService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<BulletinScope>> GetBulletinScopesByAcademicProgramId(int academicProgramId)
    {
        return await _dbModel
            .Include(bs => bs.Bulletin)
            .Include(bs => bs.AcademicProgramId)
            .Where(bs => bs.AcademicProgramId == academicProgramId)
            .ToListAsync();
    }

    public async Task<ICollection<BulletinScope>> GetBulletinScopesByBulletinId(int bulletinId)
    {
        return await _dbModel
            .Include(bs => bs.Bulletin)
            .Include(bs => bs.AcademicProgramId)
            .Where(bs => bs.BulletinId == bulletinId)
            .ToListAsync();
    }
}
