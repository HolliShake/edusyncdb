
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class TableObjectService:GenericService<TableObject>, ITableObjectService
{
    public TableObjectService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<TableObject>> GetParentObject()
    {
        return await _dbModel.Where(p => p.ParentId == null).ToListAsync();
    }

    public async Task<ICollection<TableObject>> GetObjectByAccountGroupId(int accountGroupId)
    {
        return await _dbModel.Where(p => p.AccountGroupId == accountGroupId).ToListAsync();
    }
}
