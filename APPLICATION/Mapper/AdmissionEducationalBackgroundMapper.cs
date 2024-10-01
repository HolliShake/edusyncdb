using AutoMapper;
using APPLICATION.Dto.AdmissionEducationalBackground;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionEducationalBackgroundMapper : Profile
{
    public AdmissionEducationalBackgroundMapper()
    {
        CreateMap<AdmissionEducationalBackgroundDto, AdmissionEducationalBackground>();
        CreateMap<AdmissionEducationalBackground, GetAdmissionEducationalBackgroundDto>();
    }
}
