
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipApplicationService:GenericService<ScholarshipApplication>, IScholarshipApplicationService
{
    public ScholarshipApplicationService(AppDbContext context):base(context)
    {
    }
}
