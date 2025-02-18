using APPLICATION.Dto.Room;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IRoomService:IGenericService<Room, GetRoomDto>
{
    public Task<ICollection<GetRoomDto>> GetRoomByBuildingId(int buildingId);
    public Task<ICollection<GetRoomDto>> GetRoomByCampusId(int campusId);
}
