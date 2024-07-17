
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class OtherSchoolService:GenericService<OtherSchool>, IOtherSchoolService
{
    public OtherSchoolService(AppDbContext context):base(context)
    {
    }
}
