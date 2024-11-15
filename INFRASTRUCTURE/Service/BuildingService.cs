using APPLICATION.Dto.Building;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class BuildingService:GenericService<Building, GetBuildingDto>, IBuildingService
{
    public BuildingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetBuildingDto>> GetBuildingByCampusId(int campusId)
    {
        var buildings = await _dbModel
        .Where(b => b.CampusId == campusId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetBuildingDto>>(buildings);
    }
}
