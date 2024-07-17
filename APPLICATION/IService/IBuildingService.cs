
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IBuildingService:IGenericService<Building>
{
    public Task<ICollection<Building>> GetBuildingByCampusId(int campusId);
}
