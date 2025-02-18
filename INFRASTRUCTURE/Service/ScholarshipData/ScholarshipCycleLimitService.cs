using AutoMapper;
using APPLICATION.Dto.ScholarshipCycleLimit;
using APPLICATION.IService.ScholarshipData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ScholarshipData;

public class ScholarshipCycleLimitService:GenericService<ScholarshipCycleLimit, GetScholarshipCycleLimitDto>, IScholarshipCycleLimitService
{
    public ScholarshipCycleLimitService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
