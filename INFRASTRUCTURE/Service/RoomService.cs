using APPLICATION.Dto.Room;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class RoomService:GenericService<Room, GetRoomDto>, IRoomService
{
    public RoomService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetRoomDto>> GetRoomByBuildingId(int buildingId)
    {
        return _mapper.Map<ICollection<GetRoomDto>>(await _dbModel.Where(r => r.BuildingId == buildingId).ToListAsync());
    }
}
