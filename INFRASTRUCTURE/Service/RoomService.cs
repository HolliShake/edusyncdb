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
        var rooms = await _dbModel
        .Where(r => r.BuildingId == buildingId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetRoomDto>>(rooms);
    }

    public async Task<ICollection<GetRoomDto>> GetRoomByCampusId(int campusId)
    {
        var rooms = await _dbModel
        .Include(r => r.Building)
        .Where(r => r.Building.CampusId == campusId)
        .Select(r => new GetRoomDto
        {
            Id = r.Id,
            RoomName = r.RoomName,
            Building = null,
            BuildingId = r.BuildingId,
            Capacity = r.Capacity,
            IsEspecializedLab = r.IsEspecializedLab,
            IsLab = r.IsLab,
        })
        .ToListAsync();
        return _mapper.Map<ICollection<GetRoomDto>>(rooms);
    }
}
