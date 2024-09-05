using APPLICATION.Dto.GradeBook;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GradeBookService:GenericService<GradeBook, GetGradeBookDto>, IGradeBookService
{
    public GradeBookService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetGradeBookDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetGradeBookDto>>(await _dbModel
            .Include(gb => gb.Schedule)
            .ToListAsync());
    }

    public async new Task<GetGradeBookDto?> GetAsync(int id)
    {
        return _mapper.Map<GetGradeBookDto?>(await _dbModel
            .Include(gb => gb.Schedule)
            .Where(gb => gb.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(GradeBook newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Schedule = await _dbContext.Schedules.FindAsync(newItem.ScheduleId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GradeBook updatedItem)
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
