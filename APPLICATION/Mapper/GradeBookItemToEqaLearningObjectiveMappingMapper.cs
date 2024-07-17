using AutoMapper;
using APPLICATION.Dto.GradeBookItemToEqaLearningObjectiveMapping;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GradeBookItemToEqaLearningObjectiveMappingMapper : Profile
{
    public GradeBookItemToEqaLearningObjectiveMappingMapper()
    {
        CreateMap<GradeBookItemToEqaLearningObjectiveMappingDto, GradeBookItemToEqaLearningObjectiveMapping>();
        CreateMap<GradeBookItemToEqaLearningObjectiveMapping, GetGradeBookItemToEqaLearningObjectiveMappingDto>();
    }
}
