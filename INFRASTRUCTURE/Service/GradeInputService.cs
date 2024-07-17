
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeInputService:GenericService<GradeInput>, IGradeInputService
{
    public GradeInputService(AppDbContext context):base(context)
    {
    }
}
