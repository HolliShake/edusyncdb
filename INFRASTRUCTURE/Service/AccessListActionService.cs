
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AccessListActionService:GenericService<AccessListAction>, IAccessListActionService
{
    public AccessListActionService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<AccessListAction>> GetAccessListActionsByAccessListId(int accessListId)
    {
        return await _dbModel.Where(ala => ala.AccessListId == accessListId).ToListAsync();
    }
}
