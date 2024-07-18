using APPLICATION.Dto.ScholarshipList;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScholarshipListService:GenericService<ScholarshipList, GetScholarshipListDto>, IScholarshipListService
{
    public ScholarshipListService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
