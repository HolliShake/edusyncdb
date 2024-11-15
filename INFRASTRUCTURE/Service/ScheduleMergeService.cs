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
        var scheduleMerged = await _dbModel
        .Include(s => s.Schedule)
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleMergeDto>>(scheduleMerged);
    }

    public async new Task<ScheduleMerge?> GetAsync(int id)
    {
        var scheduleMerge = await _dbModel
        .Include(s => s.Schedule)
        .Where(s => s.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return scheduleMerge;
    }

    public async new Task<GetScheduleMergeDto?> CreateAsync(ScheduleMerge newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Schedule = _dbContext.Schedules.Find(newItem.ScheduleId);
            return _mapper.Map<GetScheduleMergeDto>(newItem);
        }
        return null;
    }

    public async new Task<GetScheduleMergeDto?> UpdateAsync(ScheduleMerge updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Schedule = _dbContext.Schedules.Find(updatedItem.ScheduleId);
            return _mapper.Map<GetScheduleMergeDto>(updatedItem);
        }
        return null;
    }
}
