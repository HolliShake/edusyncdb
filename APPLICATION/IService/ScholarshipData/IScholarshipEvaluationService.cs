using APPLICATION.Dto.ScholarshipEvaluation;
using DOMAIN.Model;

namespace APPLICATION.IService.ScholarshipData;

public interface IScholarshipEvaluationService:IGenericService<ScholarshipEvaluation, GetScholarshipEvaluationDto>
{
}
