using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Building;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

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
