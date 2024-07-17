
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipEvaluationService:GenericService<ScholarshipEvaluation>, IScholarshipEvaluationService
{
    public ScholarshipEvaluationService(AppDbContext context):base(context)
    {
    }
}
