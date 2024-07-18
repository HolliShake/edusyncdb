using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceProgramObjectiveService:GenericService<EducationalQualityAssuranceProgramObjective, GetEducationalQualityAssuranceProgramObjectiveDto>, IEducationalQualityAssuranceProgramObjectiveService
{
    public EducationalQualityAssuranceProgramObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
