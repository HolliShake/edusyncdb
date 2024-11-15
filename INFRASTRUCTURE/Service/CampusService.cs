using APPLICATION.Dto.Campus;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CampusService:GenericService<Campus, GetCampusDto>, ICampusService
{
    public CampusService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCampusDto>> GetCampusByAgendyId(int agencyId)
    {
        var campuses = await _dbModel
        .Where(c => c.AgencyId == agencyId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCampusDto>>(campuses);
    }
}
