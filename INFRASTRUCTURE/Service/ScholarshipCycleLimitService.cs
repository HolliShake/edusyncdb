using APPLICATION.Dto.ScholarshipCycleLimit;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipCycleLimitService:GenericService<ScholarshipCycleLimit, GetScholarshipCycleLimitDto>, IScholarshipCycleLimitService
{
    public ScholarshipCycleLimitService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
