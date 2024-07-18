using APPLICATION.Dto.Cycle;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CycleService:GenericService<Cycle, GetCycleDto>, ICycleService
{
    public CycleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCycleDto>> GetCycleByCampusId(int campusId)
    {
        return _mapper.Map<ICollection<GetCycleDto>>(await _dbModel.Where(c => c.CampusId == campusId).ToListAsync());
    }
}
