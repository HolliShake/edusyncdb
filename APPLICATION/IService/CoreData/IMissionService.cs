using APPLICATION.Dto.Mission;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IMissionService:IGenericService<Mission, GetMissionDto>
{
}