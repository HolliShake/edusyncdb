using APPLICATION.Dto.LikertQuestion;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ILikertQuestionService:IGenericService<LikertQuestion, GetLikertQuestionDto>
{
}
