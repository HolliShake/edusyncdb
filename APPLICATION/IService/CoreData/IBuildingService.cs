using APPLICATION.Dto.Building;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IBuildingService:IGenericService<Building, GetBuildingDto>
{
    public Task<ICollection<GetBuildingDto>> GetBuildingByCampusId(int campusId);
}
