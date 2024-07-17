
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GraduationCampusService:GenericService<GraduationCampus>, IGraduationCampusService
{
    public GraduationCampusService(AppDbContext context):base(context)
    {
    }
}
