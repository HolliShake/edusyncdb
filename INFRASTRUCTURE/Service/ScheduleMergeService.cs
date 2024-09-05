using APPLICATION.Dto.ScheduleMerge;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleMergeService:GenericService<ScheduleMerge, GetScheduleMergeDto>, IScheduleMergeService
{
    public ScheduleMergeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetScheduleMergeDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetScheduleMergeDto>>(await _dbModel
            .Include(s => s.Schedule)
            .ToListAsync());
    }

    public async new Task<GetScheduleMergeDto?> GetAsync(int id)
    {
        return _mapper.Map<GetScheduleMergeDto?>(await _dbModel
            .Include(s => s.Schedule)
            .Where(s => s.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(ScheduleMerge newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Schedule = await _dbContext.Schedules.FindAsync(newItem.ScheduleId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(ScheduleMerge updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Schedule = await _dbContext.Schedules.FindAsync(updatedItem.ScheduleId);
        }
        return result;
    }
}
