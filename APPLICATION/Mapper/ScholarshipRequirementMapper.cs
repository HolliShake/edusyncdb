using AutoMapper;
using APPLICATION.Dto.ScholarshipRequirement;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScholarshipRequirementMapper : Profile
{
    public ScholarshipRequirementMapper()
    {
        CreateMap<ScholarshipRequirementDto, ScholarshipRequirement>();
        CreateMap<ScholarshipRequirement, GetScholarshipRequirementDto>();
    }
}
