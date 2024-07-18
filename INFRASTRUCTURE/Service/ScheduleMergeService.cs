using APPLICATION.Dto.ScheduleMerge;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleMergeService:GenericService<ScheduleMerge, GetScheduleMergeDto>, IScheduleMergeService
{
    public ScheduleMergeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
