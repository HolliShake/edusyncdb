using APPLICATION.Dto.Mission;
using APPLICATION.IService.CoreData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class MissionService : GenericService<Mission, GetMissionDto>, IMissionService
{
    public MissionService(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}