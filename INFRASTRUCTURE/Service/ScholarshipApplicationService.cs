using APPLICATION.Dto.ScholarshipApplication;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipApplicationService:GenericService<ScholarshipApplication, GetScholarshipApplicationDto>, IScholarshipApplicationService
{
    public ScholarshipApplicationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
