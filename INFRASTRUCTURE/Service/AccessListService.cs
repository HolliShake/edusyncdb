
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AccessListService:GenericService<AccessList>, IAccessListService
{
    public AccessListService(AppDbContext context):base(context)
    {
    }

    public new async Task<ICollection<AccessList>> GetAllAsync()
    {
        return await _dbModel.Include(al => al.AccessListActions).ToListAsync();
    }
    
    public new async Task<AccessList?> GetAsync(int id)
    {
        return await _dbModel.Include(al => al.AccessListActions).Where(al => al.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AccessList>> GetGroups()
    {
        return await _dbModel
            .Include(al => al.AccessListActions)
            .Where(al => al.IsGroup)
            .ToListAsync();
    }
}
