using APPLICATION.Dto.ScholarshipRequirement;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipRequirementService:GenericService<ScholarshipRequirement, GetScholarshipRequirementDto>, IScholarshipRequirementService
{
    public ScholarshipRequirementService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
