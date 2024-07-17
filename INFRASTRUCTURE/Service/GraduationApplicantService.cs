
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GraduationApplicantService:GenericService<GraduationApplicant>, IGraduationApplicantService
{
    public GraduationApplicantService(AppDbContext context):base(context)
    {
    }
}
