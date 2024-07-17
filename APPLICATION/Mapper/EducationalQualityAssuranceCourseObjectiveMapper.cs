using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceCourseObjectiveMapper : Profile
{
    public EducationalQualityAssuranceCourseObjectiveMapper()
    {
        CreateMap<EducationalQualityAssuranceCourseObjectiveDto, EducationalQualityAssuranceCourseObjective>();
        CreateMap<EducationalQualityAssuranceCourseObjective, GetEducationalQualityAssuranceCourseObjectiveDto>();
    }
}
