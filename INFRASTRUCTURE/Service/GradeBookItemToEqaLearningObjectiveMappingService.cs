
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemToEqaLearningObjectiveMappingService:GenericService<GradeBookItemToEqaLearningObjectiveMapping>, IGradeBookItemToEqaLearningObjectiveMappingService
{
    public GradeBookItemToEqaLearningObjectiveMappingService(AppDbContext context):base(context)
    {
    }
}
