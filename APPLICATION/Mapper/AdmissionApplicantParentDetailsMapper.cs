using AutoMapper;
using APPLICATION.Dto.AdmissionApplicantFamilyDetails;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionApplicantParentDetailsMapper : Profile
{
    public AdmissionApplicantParentDetailsMapper()
    {
        CreateMap<AdmissionApplicantParentDetailsDto, AdmissionApplicantFamilyDetails>();
        CreateMap<AdmissionApplicantFamilyDetails, GetAdmissionApplicantParentDetailsDto>();
    }
}
