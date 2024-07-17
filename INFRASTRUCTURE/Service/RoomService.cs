
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class RoomService:GenericService<Room>, IRoomService
{
    public RoomService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Room>> GetRoomByBuildingId(int buildingId)
    {
        return await _dbModel.Where(r => r.BuildingId == buildingId).ToListAsync();
    }
}
