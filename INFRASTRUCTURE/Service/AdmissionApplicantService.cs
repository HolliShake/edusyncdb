
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AdmissionApplicantService:GenericService<AdmissionApplicant>, IAdmissionApplicantService
{
    public AdmissionApplicantService(AppDbContext context):base(context)
    {
    }
}
