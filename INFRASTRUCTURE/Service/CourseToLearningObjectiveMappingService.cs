using APPLICATION.Dto.CourseToLearningObjectiveMapping;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseToLearningObjectiveMappingService:GenericService<CourseToLearningObjectiveMapping, GetCourseToLearningObjectiveMappingDto>, ICourseToLearningObjectiveMappingService
{
    public CourseToLearningObjectiveMappingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
