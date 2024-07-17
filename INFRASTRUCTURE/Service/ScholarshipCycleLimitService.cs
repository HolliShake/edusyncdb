
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipCycleLimitService:GenericService<ScholarshipCycleLimit>, IScholarshipCycleLimitService
{
    public ScholarshipCycleLimitService(AppDbContext context):base(context)
    {
    }
}
