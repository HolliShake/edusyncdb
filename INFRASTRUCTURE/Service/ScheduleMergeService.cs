
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleMergeService:GenericService<ScheduleMerge>, IScheduleMergeService
{
    public ScheduleMergeService(AppDbContext context):base(context)
    {
    }
}
