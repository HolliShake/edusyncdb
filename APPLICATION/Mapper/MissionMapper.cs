
using APPLICATION.Dto.Mission;
using AutoMapper;
using DOMAIN.Model;

namespace APPLICATION.Mapper;

public class MissionMapper: Profile
{
    public MissionMapper()
    {
        CreateMap<MissionDto, Mission>();
        CreateMap<Mission, GetMissionDto>();
    }
}