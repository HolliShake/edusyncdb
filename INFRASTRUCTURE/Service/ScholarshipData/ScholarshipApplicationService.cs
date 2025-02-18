using AutoMapper;
using APPLICATION.Dto.ScholarshipApplication;
using APPLICATION.IService.ScholarshipData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ScholarshipData;

public class ScholarshipApplicationService:GenericService<ScholarshipApplication, GetScholarshipApplicationDto>, IScholarshipApplicationService
{
    public ScholarshipApplicationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
