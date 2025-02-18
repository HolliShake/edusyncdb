using APPLICATION.Dto.GradeBookItemToEqaLearningObjectiveMapping;
using APPLICATION.IService.GradeBookData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.GradeBookData;

public class GradeBookItemToEqaLearningObjectiveMappingService:GenericService<GradeBookItemToEqaLearningObjectiveMapping, GetGradeBookItemToEqaLearningObjectiveMappingDto>, IGradeBookItemToEqaLearningObjectiveMappingService
{
    public GradeBookItemToEqaLearningObjectiveMappingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
