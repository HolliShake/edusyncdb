using APPLICATION.Dto.Room;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IRoomService:IGenericService<Room, GetRoomDto>
{
    public Task<ICollection<GetRoomDto>> GetRoomByBuildingId(int buildingId);
}
