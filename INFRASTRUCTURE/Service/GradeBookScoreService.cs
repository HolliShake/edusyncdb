
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookScoreService:GenericService<GradeBookScore>, IGradeBookScoreService
{
    public GradeBookScoreService(AppDbContext context):base(context)
    {
    }
}
