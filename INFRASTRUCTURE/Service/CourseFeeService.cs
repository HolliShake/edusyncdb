
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseFeeService:GenericService<CourseFee>, ICourseFeeService
{
    public CourseFeeService(AppDbContext context):base(context)
    {
    }
}
