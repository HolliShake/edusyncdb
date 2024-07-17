
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class LikertQuestionService:GenericService<LikertQuestion>, ILikertQuestionService
{
    public LikertQuestionService(AppDbContext context):base(context)
    {
    }
}
