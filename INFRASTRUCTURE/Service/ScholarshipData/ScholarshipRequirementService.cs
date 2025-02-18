using AutoMapper;
using APPLICATION.Dto.ScholarshipRequirement;
using APPLICATION.IService.ScholarshipData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ScholarshipData;

public class ScholarshipRequirementService:GenericService<ScholarshipRequirement, GetScholarshipRequirementDto>, IScholarshipRequirementService
{
    public ScholarshipRequirementService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
