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

    public async new Task<ICollection<GetCycleDto>> GetAllAsync()
    {
        var cycles = await _dbModel
        .Include(c => c.Campus)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCycleDto>>(cycles);
    }

    public async new Task<GetCycleDto?> GetAsync(int id)
    {
        var cycle = await _dbModel
        .Include(c => c.Campus)
        .Where(c => c.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return _mapper.Map<GetCycleDto?>(cycle);
    }

    public async Task<ICollection<GetCycleDto>> GetCycleByCampusId(int campusId)
    {
        var cycles = await _dbModel
        .Include(c => c.Campus)
        .Where(c => c.CampusId == campusId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCycleDto>>(cycles);
    }
}
