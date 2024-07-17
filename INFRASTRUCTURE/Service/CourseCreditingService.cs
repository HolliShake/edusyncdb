
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseCreditingService:GenericService<CourseCrediting>, ICourseCreditingService
{
    public CourseCreditingService(AppDbContext context):base(context)
    {
    }
}
