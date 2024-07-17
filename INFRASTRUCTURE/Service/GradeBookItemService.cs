
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemService:GenericService<GradeBookItem>, IGradeBookItemService
{
    public GradeBookItemService(AppDbContext context):base(context)
    {
    }
}
