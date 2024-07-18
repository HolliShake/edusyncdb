using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceLearningObjectiveService:GenericService<EducationalQualityAssuranceLearningObjective, GetEducationalQualityAssuranceLearningObjectiveDto>, IEducationalQualityAssuranceLearningObjectiveService
{
    public EducationalQualityAssuranceLearningObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
