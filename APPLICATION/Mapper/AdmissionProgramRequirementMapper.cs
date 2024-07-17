using AutoMapper;
using APPLICATION.Dto.AdmissionProgramRequirement;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionProgramRequirementMapper : Profile
{
    public AdmissionProgramRequirementMapper()
    {
        CreateMap<AdmissionProgramRequirementDto, AdmissionProgramRequirement>();
        CreateMap<AdmissionProgramRequirement, GetAdmissionProgramRequirementDto>();
    }
}
