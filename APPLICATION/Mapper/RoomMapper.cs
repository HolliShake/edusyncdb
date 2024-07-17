using AutoMapper;
using APPLICATION.Dto.Room;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class RoomMapper : Profile
{
    public RoomMapper()
    {
        CreateMap<RoomDto, Room>();
        CreateMap<Room, GetRoomDto>();
    }
}
