using AutoMapper;
using APPLICATION.Dto.AdmissionApplicant;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionApplicantMapper : Profile
{
    public AdmissionApplicantMapper()
    {
        CreateMap<AdmissionApplicantDto, AdmissionApplicant>();
        CreateMap<AdmissionApplicant, GetAdmissionApplicantDto>();
    }
}
