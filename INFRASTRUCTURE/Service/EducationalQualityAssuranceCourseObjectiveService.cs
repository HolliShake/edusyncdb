using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceCourseObjectiveService:GenericService<EducationalQualityAssuranceCourseObjective, GetEducationalQualityAssuranceCourseObjectiveDto>, IEducationalQualityAssuranceCourseObjectiveService
{
    public EducationalQualityAssuranceCourseObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
