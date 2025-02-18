using AutoMapper;
using APPLICATION.Dto.CourseToLearningObjectiveMapping;
using APPLICATION.IService.MappingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.MappingData;

public class CourseToLearningObjectiveMappingService:GenericService<CourseToLearningObjectiveMapping, GetCourseToLearningObjectiveMappingDto>, ICourseToLearningObjectiveMappingService
{
    public CourseToLearningObjectiveMappingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
