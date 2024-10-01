
using APPLICATION.Dto.AdmissionApplicantFamilyDetails;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AdmissionApplicantFamilyDetailsService:GenericService<AdmissionApplicantFamilyDetails, GetAdmissionApplicantParentDetailsDto>, IAdmissionApplicantFamilyDetailsService
{
    public AdmissionApplicantFamilyDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
