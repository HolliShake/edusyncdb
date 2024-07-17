
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class RequirementService:GenericService<Requirement>, IRequirementService
{
    public RequirementService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Requirement>> GetActiveRequirement()
    {
        return await _dbModel.Where(r => r.IsActive).ToListAsync();
    }
}
