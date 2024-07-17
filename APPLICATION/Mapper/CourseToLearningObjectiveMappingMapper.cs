using AutoMapper;
using APPLICATION.Dto.CourseToLearningObjectiveMapping;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CourseToLearningObjectiveMappingMapper : Profile
{
    public CourseToLearningObjectiveMappingMapper()
    {
        CreateMap<CourseToLearningObjectiveMappingDto, CourseToLearningObjectiveMapping>();
        CreateMap<CourseToLearningObjectiveMapping, GetCourseToLearningObjectiveMappingDto>();
    }
}
