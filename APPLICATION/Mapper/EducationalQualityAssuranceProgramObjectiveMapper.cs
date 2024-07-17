using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceProgramObjectiveMapper : Profile
{
    public EducationalQualityAssuranceProgramObjectiveMapper()
    {
        CreateMap<EducationalQualityAssuranceProgramObjectiveDto, EducationalQualityAssuranceProgramObjective>();
        CreateMap<EducationalQualityAssuranceProgramObjective, GetEducationalQualityAssuranceProgramObjectiveDto>();
    }
}
