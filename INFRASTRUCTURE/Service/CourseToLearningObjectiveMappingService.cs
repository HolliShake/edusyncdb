
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class CourseToLearningObjectiveMappingService:GenericService<CourseToLearningObjectiveMapping>, ICourseToLearningObjectiveMappingService
{
    public CourseToLearningObjectiveMappingService(AppDbContext context):base(context)
    {
    }
}
