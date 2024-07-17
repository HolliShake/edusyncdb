
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemDetailService:GenericService<GradeBookItemDetail>, IGradeBookItemDetailService
{
    public GradeBookItemDetailService(AppDbContext context):base(context)
    {
    }
}
