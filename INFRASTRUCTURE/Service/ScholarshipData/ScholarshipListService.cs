using AutoMapper;
using APPLICATION.Dto.ScholarshipList;
using APPLICATION.IService.ScholarshipData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ScholarshipData;

public class ScholarshipListService:GenericService<ScholarshipList, GetScholarshipListDto>, IScholarshipListService
{
    public ScholarshipListService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
