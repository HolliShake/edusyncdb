using AutoMapper;
using APPLICATION.Dto.Building;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class BuildingMapper : Profile
{
    public BuildingMapper()
    {
        CreateMap<BuildingDto, Building>();
        CreateMap<Building, GetBuildingDto>();
    }
}
