using AutoMapper;
using APPLICATION.Dto.ScholarshipEvaluation;
using APPLICATION.IService.ScholarshipData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ScholarshipData;

public class ScholarshipEvaluationService:GenericService<ScholarshipEvaluation, GetScholarshipEvaluationDto>, IScholarshipEvaluationService
{
    public ScholarshipEvaluationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
