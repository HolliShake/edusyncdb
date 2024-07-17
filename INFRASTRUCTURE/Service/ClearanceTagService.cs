
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ClearanceTagService:GenericService<ClearanceTag>, IClearanceTagService
{
    public ClearanceTagService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<ClearanceTag>> GetClearanceTagsByClearanceTypeId(int clearanceTypeId)
    {
        return await _dbModel.Where(ct => ct.ClearanceTypeId == clearanceTypeId).ToListAsync();
    }
}
