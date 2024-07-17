
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookService:GenericService<GradeBook>, IGradeBookService
{
    public GradeBookService(AppDbContext context):base(context)
    {
    }
}
