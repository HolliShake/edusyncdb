
using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AdmissionApplicantService:GenericService<AdmissionApplicant, GetAdmissionApplicantDto>, IAdmissionApplicantService
{
    public AdmissionApplicantService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
