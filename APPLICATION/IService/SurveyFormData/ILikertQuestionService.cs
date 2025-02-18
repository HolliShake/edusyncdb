using APPLICATION.Dto.LikertQuestion;
using DOMAIN.Model;

namespace APPLICATION.IService.SurveyFormData;

public interface ILikertQuestionService:IGenericService<LikertQuestion, GetLikertQuestionDto>
{
}
