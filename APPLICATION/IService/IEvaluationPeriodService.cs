using APPLICATION.Dto.EvaluationPeriod;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEvaluationPeriodService:IGenericService<EvaluationPeriod, GetEvaluationPeriodDto>
{
    public Task<object> GetAllEvaluationTeachsByEvaluationPeriodAndUserId(string userId, int evaluationPeriodId);
    public Task<object?> GetEvaluationPeriodInformation(int id);
    public Task<object> GetOpenEvaluationPeriodByEnrollmentUserId(string userId);
}
