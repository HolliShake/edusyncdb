
using APPLICATION.Dto.AdmissionApplicantFamilyDetails;
using APPLICATION.IService.AdmissionData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AdmissionData;

public class AdmissionApplicantFamilyDetailsService:GenericService<AdmissionApplicantFamilyDetails, GetAdmissionApplicantParentDetailsDto>, IAdmissionApplicantFamilyDetailsService
{
    public AdmissionApplicantFamilyDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
