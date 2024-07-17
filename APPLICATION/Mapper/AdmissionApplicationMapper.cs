using AutoMapper;
using APPLICATION.Dto.AdmissionApplication;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionApplicationMapper : Profile
{
    public AdmissionApplicationMapper()
    {
        CreateMap<AdmissionApplicationDto, AdmissionApplication>();
        CreateMap<AdmissionApplication, GetAdmissionApplicationDto>();
    }
}
