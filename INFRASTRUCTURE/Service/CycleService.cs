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
        return _mapper.Map<ICollection<GetCycleDto>>(await _dbModel.Include(c => c.Campus).ToListAsync());
    }

    public async new Task<GetCycleDto?> GetAsync(int id)
    {
        return _mapper.Map<GetCycleDto?>(await _dbModel.Include(c => c.Campus).Where(c => c.Id == id).FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetCycleDto>> GetCycleByCampusId(int campusId)
    {
        return _mapper.Map<ICollection<GetCycleDto>>(await _dbModel
            .Include(c => c.Campus)
            .Where(c => c.CampusId == campusId).ToListAsync());
    }
}
