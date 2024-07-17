using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceLearningObjectiveMapper : Profile
{
    public EducationalQualityAssuranceLearningObjectiveMapper()
    {
        CreateMap<EducationalQualityAssuranceLearningObjectiveDto, EducationalQualityAssuranceLearningObjective>();
        CreateMap<EducationalQualityAssuranceLearningObjective, GetEducationalQualityAssuranceLearningObjectiveDto>();
    }
}
