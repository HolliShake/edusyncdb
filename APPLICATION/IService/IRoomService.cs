
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IRoomService:IGenericService<Room>
{
    public Task<ICollection<Room>> GetRoomByBuildingId(int buildingId);
}
