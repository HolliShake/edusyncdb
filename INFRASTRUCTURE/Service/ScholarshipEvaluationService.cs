using APPLICATION.Dto.ScholarshipEvaluation;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipEvaluationService:GenericService<ScholarshipEvaluation, GetScholarshipEvaluationDto>, IScholarshipEvaluationService
{
    public ScholarshipEvaluationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
