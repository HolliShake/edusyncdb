using APPLICATION.Dto.LikertQuestion;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class LikertQuestionService:GenericService<LikertQuestion, GetLikertQuestionDto>, ILikertQuestionService
{
    public LikertQuestionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
