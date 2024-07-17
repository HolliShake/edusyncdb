using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceAssessmentTypeMapper : Profile
{
    public EducationalQualityAssuranceAssessmentTypeMapper()
    {
        CreateMap<EducationalQualityAssuranceAssessmentTypeDto, EducationalQualityAssuranceAssessmentType>();
        CreateMap<EducationalQualityAssuranceAssessmentType, GetEducationalQualityAssuranceAssessmentTypeDto>();
    }
}
