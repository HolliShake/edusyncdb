
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipListService:GenericService<ScholarshipList>, IScholarshipListService
{
    public ScholarshipListService(AppDbContext context):base(context)
    {
    }
}
